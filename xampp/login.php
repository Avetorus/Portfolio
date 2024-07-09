<?php
session_start();
require "module/module.php";
// Debug $db (koneksi database) dengan benar di file module.php
/*if($db){
    echo "connected";
}else{
    echo "failed";
}
die;*/


// Cek cookie untuk login otomatis
if (isset($_COOKIE["id"]) && isset($_COOKIE['key'])) {
    $id = $_COOKIE['id'];
    $key = $_COOKIE['key'];

    // Ambil username dari id
    $result = mysqli_query($db, "SELECT username FROM users WHERE id = '$id'");
    if ($result) {
        $row = mysqli_fetch_assoc($result);

        // Periksa kesesuaian key dengan username
        if ($key == hash('sha256', $row['username'])) {
            $_SESSION['login'] = true;
        }
    }
}

// Redirect jika sudah login
if (isset($_SESSION["login"])) {
    header("Location: index.php");
    exit();
}

// Query untuk mendapatkan semua data user
$login = mysqli_query($db, "SELECT * FROM users");
if (!$login) {
    die("Query Error: " . mysqli_error($db));
}

// Pengecekan login dengan username dan password
if (isset($_POST["login"])) {
    $username = $_POST["username"];
    $password = $_POST["password"];
    // Inisialisasi error
    $errorPass = $errorUser = false;

    // Loop untuk mencocokkan username dan password dari hasil query
    $foundUser = false;
    while ($log = mysqli_fetch_assoc($login)) {
        if ($log["username"] === $username) {
            $foundUser = true;            
            if (password_verify($password, $log["password"])) {
                $_SESSION["login"] = true;

                // Set cookie jika Remember Me diaktifkan
                if (isset($_POST["remember"])) {
                    setcookie('id', $log['id'], time() + 3600);
                    setcookie('key', hash('sha256', $log['username']), time() + 3600);
                }

                header("Location: index.php");
                exit();
            } else {
                $errorPass = true;
            }
        }
    }

    // Tandai error jika username tidak ditemukan
    if (!$foundUser) {
        $errorUser = true;
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link rel="stylesheet" href="styles/stylelogin.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>
    <div class="container">
        <form action="" method="post">
            <h1>Login</h1>
            <div class="input-box">
                <input type="text" name="username" placeholder="Username" required>
                <i class='bx bxs-user'></i>
            </div>
            <div class="input-box">
                <input type="password" name="password" placeholder="Password" required>
                <i class='bx bxs-lock-alt'></i>
            </div>
            <div class="remember-forgot">
                <label><input type="checkbox" name="remember"> Remember me</label>
                <a href="#" name="forgot">Forgot Password?</a>
            </div>
            <button type="submit" name="login" class="login">Login</button>
            <?php if (isset($errorUser) && $errorUser): ?>
                <p style="color: red; font-style: italic;" class="invalid">Username not registered!</p>
            <?php elseif (isset($errorPass) && $errorPass): ?>
                <p style="color: red; font-style: italic;" class="invalid">Password not matched!</p>
            <?php endif; ?>
            <div class="register">Don't have an account? <a href="register.php" name="register">Register</a></div>
        </form>
    </div>
</body>
</html>
