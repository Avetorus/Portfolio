<?php
session_start();

// Pastikan variabel $_SESSION["login"] sudah ada sebelum digunakan
if (!isset($_SESSION["login"]) || !$_SESSION["login"]) {
    header("Location: login.php");
    exit();
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Portfolio</title>
    <link rel="stylesheet" href="styles/styleindex.css">
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
    <script src="https://unpkg.com/typed.js@2.1.0/dist/typed.umd.js"></script>
</head>
<body>
    <!-- Header -->
    <header class="header">
        <!-- Navbar -->
        <nav>
            <h1 class="logo">UnlceWick</h1>
            <ul>
                <li><a href="#">Home</a></li>
                <li><a href="products\product1.php">About</a></li>
                <li><a href="products\product.php?product">Product</a></li>
                <li><a href="#">Contact</a></li>
            </ul>
            <img src="assets/user.png" alt="user" class="user" onclick="toggleMenu()">

            <!-- Menu Wrap -->
             <div class="menu-wrap" id="subMenu">
                <div class="sub-menu">
                    <div class="user-info">
                        <img src="assets/user.png" alt="user" class="user">
                        <h2>Vincent</h2>
                    </div>
                    <hr>
                    <a href="#" class="sub-menu-link">
                    <img src="assets/user-profile.png" alt=""><p>Profile</p>
                    <span>></span>
                    </a>
                    <a href="#" class="sub-menu-link">
                    <img src="assets/setting.png" alt=""><p>Setting</p> 
                    <span>></span>
                    </a>
                    <a href="#" class="sub-menu-link">
                    <img src="assets/support.png" alt=""><p>Support</p>
                    <span>></span>
                    </a>
                    <a href="logout.php" class="sub-menu-link">
                    <img src="assets/logout.png" alt=""><p>Logout</p>
                    <span>></span>
                    </a>
                </div>
             </div>
        </nav>
    </header>

    <!-- Main -->
    <section class="home">
        <div class="home-content">
            <h3>Hello,</h3>
            <h1>I'm Vincent</h3>
            <h3>:<span class="text"></span></h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Rerum, libero officiis placeat eveniet recusandae sequi autem voluptates, vitae eaque voluptatibus provident cum ex veritatis! Est at magni illo voluptas explicabo.</p>
            <div class="home-sci">
                <a href="#"><i class='bx bxl-linkedin-square' ></i></a>
                <a href="#"><i class='bx bxl-whatsapp' ></i></a>
                <a href="#"><i class='bx bxl-instagram' ></i></a>
                <a href="#"><i class='bx bxl-facebook-circle' ></i></a>
            </div>
            <a href="#" class="btn-box">More About Me</a>
        </div>
    </section>

    <!-- Footer Site -->
    <div class="footer">
        <h5>Copyright 2024. Vincent</h5>
    </div>
    <script src="script/main.js"></script>
</body>
</html>