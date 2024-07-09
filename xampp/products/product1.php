<?php 
//check session from login 
session_start();
if( !$_SESSION["login"] ){
    header("Location: ../login.php");
    exit();
}
require '..\module\module.php';
$produk = query("SELECT * FROM produk");
function rupiah($number){
    $result = "Rp.".number_format($number, 2,',','.');
    return $result;
}

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>About</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.tailwindcss.com"></script>
    <link rel="stylesheet" href="../styles/styleproduct.css">
</head>
<body class="bg-gradient-to-r from-cyan-500 to-blue-500">
  <header class="bg-white shadow">
    <div class="mx-auto max-w-7xl px-4 py-6 sm:px-6 lg:px-8">
      <h1 class="text-3xl font-bold tracking-tight text-gray-900">About</h1>
    </div>
  </header>
  <button type="button" class="btn btn-warning"><a href="../index.php" style="text-decoration: none;">Back to Home</a></button>
    <div class="gallery">
    <?php foreach($produk as $item):?>
        <div class="content">
            <img src="../tmp/<?=$item["gambar"]?>" alt="<?=$item["nama_produk"];?>">
            <h3><?= $item["nama_produk"];?></h3>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Repellat architecto recusandae in eligendi, explicabo dolorem corrupti dignissimos quae iure. Porro quo quaerat perferendis neque molestias illo, fugit beatae fuga laborum!</p>
            <h6><?=rupiah($item["harga"]);?></h6>
            <button class="buy">Buy Now</button>
        </div>
    <?php endforeach;?>
    </div>
</body>
</html>