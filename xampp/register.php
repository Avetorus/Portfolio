<?php
// //Auto reload webpage
// if(isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] === 'on'){
//     $url="https://";
// }else{
//     $url= "https://";
//     $url.=$_SERVER['HTTP_HOST'];
//     $url.=$_SERVER['REQUEST_URI'];
//     $url;
// }
// $page=$url;
// $sec="5";

// //check session from login 
// session_start();
// if( !$_SESSION["enter"] ){
//     header("Location: login.php");
//     exit();
// }

require 'module/module.php';

if(isset($_POST["register"])){
    $registerResult = register($_POST);
    if($registerResult > 0){
        echo "<script>
                alert('Success Register');
              </script>";
              header('Location: login.php');
    } else {
        echo "<script>
                alert('Registration failed: " . mysqli_error($db) . "');
              </script>";
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register</title>
    <link rel="stylesheet" href="styles/styleregister.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
</head>
<body>
    <div class="container">
        <form action="" method="post">
            <h1>Register</h1>
            <!-- Username -->
            <div class="input-box">
                <input type="text" name="name" placeholder="Name" required autocomplete="off">
            </div>
            
            <!-- Username -->
            <div class="input-box">
                <input type="text" name="username" placeholder="Username" required autocomplete="off">
                <i class='bx bxs-user'></i>
            </div>

            <!-- Password -->
            <div class="input-box">
                <input type="password" name="password" placeholder="Password" required autocomplete="off">
                <i class='bx bxs-lock-alt' ></i>
            </div>

            <div class="input-box">
                <input type="password" name="rePassword" placeholder="Re-Password" required autocomplete="off">
                <i class='bx bxs-lock-alt' ></i>
            </div>

            <!-- Submit Register -->
            <button type="submit" name="register" class="register">Register</button>
            
            <!-- Invalid -->
            <?php if(isset($error)):?>
                <p style="color: red; font-style: italic;" class="invalid">username/password not matched!</p>
            <?php endif;?>

            <!-- Back to Login -->
            <div class="login"><a href="login.php" name="login">Back to Login?</a></div>
        </form>
    </div>
</body>
</html>