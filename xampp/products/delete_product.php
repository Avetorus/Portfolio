<?php
//check session from login 
session_start();
if( !$_SESSION["login"] ){
    header("Location: ../login.php");
    exit();
}

$del = $_POST["no_seri"];

if( !isset($del) ){
    header("Location: product.php");
    exit();
}

require "../module/module.php";
//terdapat fungsi delete di module,
//jika dipakai hasilkan 1 namun diterima 0
//fungsi del disini pengganti delete dari module
function del($i){
    global $db;
    mysqli_query($db, "DELETE FROM produk WHERE no_seri = '$i'");
 return mysqli_affected_rows($db);
}

if(del($del) > 0){
    // Check if delete was successful
        echo "
            <script>
                alert('Data Berhasil dihapus!');
                document.location.href = 'product.php';
            </script>
        ";
}else{
    echo "
            <script>
                alert('Data Gagal dihapus!');
                document.location.href = 'product.php';
            </script>
        ";
}
?>