<?php

//check session from login 
session_start();
if( !$_SESSION["login"] ){
    header("Location: ../login.php");
    exit();
}

$add = $_GET["add"];
if( !isset($add) ){
    header("Location: product.php");
    exit();
}

// if(isset($_POST[])){

// }
require '..\module\module.php';
//Check if form is submitted
if(isset($_POST["submit"])){     

    //DEBUG
    // var_dump($_POST);
    // var_dump($_FILES);die;

    // Check if insert was successful
    if(tambah($_POST)>0){
        echo "
            <script>
                alert('Data Berhasil dimasukkan!');
                document.location.href = 'product.php';
            </script>
        ";
    }else{
        echo "
        <script>
            alert('Data Gagal dimasukkan!');
            document.location.href = 'product.php';
        </script>
        ";
    }
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tambah Data Product</title>
    <style>
        form{
            border: 2px solid;
        }
        input{
            margin: 2px;
        }
    </style>
</head>
<body>
    <h1>Tambah Data Product</h1>
    <form action="" method="post" enctype="multipart/form-data">
        <ul>
            <li>
                <label for="fnoseri">No Seri </label>
                <input type="text" name="no_seri" id="fnoseri" placeholder="AAAA-BBBB" required>
            </li>
            <li>
            <label for="fnamaproduk">Nama Produk </label>
                <input type="text" name="nama_produk" id="fnamaproduk" placeholder="Produk A" required>
            </li>
            <li>
                <label for="fjenis">Jenis </label>
                <input type="text" name="jenis" id="fjenis" placeholder="Tipe A" required>
            </li>
            <li>
            <label for="fharga">Harga </label>
                <input type="text" name="harga" id="fharga" placeholder="XXXXXXX" required>
            </li>
            <li>
            <label for="fgambar">Gambar </label>
                <input type="file" name="gambar" id="fgambar">
            </li>
            <li>
                <button type="submit" name="submit">Add Data</button>
            </li>
        </ul>
    </form>   
    <a href="product.php?product">Back to Product List</a>
</body>
</html>