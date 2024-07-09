<?php 

echo 'Hello World';

$db = mysqli_connect(
   'db',     // atau alamat IP container MySQL jika perlu
   'user', 
   'pass',          // ganti dengan kata sandi yang benar
   'iot',             
);

if (!$db) {
    die('Koneksi database gagal: ' . mysqli_connect_error());
}

echo 'Koneksi database berhasil!';
?>
