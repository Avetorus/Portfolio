<?php
//check session from login 
session_start();
if( !$_SESSION["login"] ){
    header("Location: ../login.php");
    exit();
}

$seri = $_POST["no_seri"];

if( !isset($seri)){
    header("Location: product.php");
    exit();
}

require "../module/module.php";

$produk = query("SELECT * FROM produk WHERE no_seri = '$seri'")[0];

if(isset($_POST["submit"])){
    if(update($_POST) > 0){
        // Check if delete was successful
            echo "
                <script>
                    alert('Data Berhasil diubah!');
                    document.location.href = 'product.php';
                </script>
            ";
    }else{
        echo "
                <script>
                    alert('Data Gagal diubah!');
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
    <title>Ubah Data Product</title>
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
    <h1>Ubah Data Product</h1>
    <form action="" method="post" enctype="multipart/form-data">
        <input type="hidden" name="gambarLama" value="<?=$produk["gambar"];?>">
        <ul>
            <li>
                <label for="fnoseri">No Seri </label>
                <input type="text" name="no_seri" id="fnoseri" placeholder="AAAA-BBBB" value="<?=$produk["no_seri"]?>" required>
            </li>
            <li>
            <label for="fnamaproduk">Nama Produk </label>
                <input type="text" name="nama_produk" id="fnamaproduk" placeholder="Produk A" value="<?=$produk["nama_produk"]?>" required>
            </li>
            <li>
                <label for="fjenis">Jenis </label>
                <input type="text" name="jenis" id="fjenis" placeholder="Tipe A" value="<?=$produk["jenis"]?>" required>
            </li>
            <li>
            <label for="fharga">Harga </label>
                <input type="text" name="harga" id="fharga" placeholder="XXXXXXX" value="<?=$produk["harga"]?>" required>
            </li>
            <li>
            <label for="fgambar">Gambar </label><br>
                <img src="assets/<?=$produk["gambar"]?>" alt="<?=$produk["gambar"]?>" width="40"><br>
                <input type="file" name="gambar" id="fgambar">
            </li><br>
            <li>
                <button type="submit" name="submit">Update Data</button>
            </li>
        </ul>
    </form>   
    <a href="product.php?product">Back to Product List</a>
</body>
</html>