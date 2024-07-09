<?php 

//check session from login 
session_start();
if( !$_SESSION["login"] ){
    header("Location: ../login.php");
    exit();
}

// if(!isset($_POST["username"])){
//     header("Location: login.php");
//     exit();
// }
require '..\module\module.php';
//pagination
//konfigurasi 
$data = 2;
$amountData = count(query('SELECT * FROM produk'));
$amountPage = ceil($amountData / $data);
$activePage = ( isset($_GET["p"]) ) ? $_GET["p"] : 1;
$awal = ($data * $activePage) - $data;


$produk = query("SELECT * FROM produk LIMIT $awal, $data");


if(isset($_POST["find"])){
    $produk = find($_POST["search"]);
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Daftar Produk</title>
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.tailwindcss.com"></script>
    <script src="../script/product.js"></script>
    <style>
        .loader{
            width: 20px;
            position: absolute;
            right: 380px;
            display: none;
        }
    </style>
</head>
<body class="bg-gradient-to-r from-cyan-500 to-blue-500">
  <header class="bg-white shadow">
    <div class="mx-auto max-w-7xl px-4 py-6 sm:px-6 lg:px-8">
      <h1 class="text-3xl font-bold tracking-tight text-gray-900">Products</h1>
    </div>
  </header>
  <main>
    <div class="mx-auto max-w-7xl px-4 py-6 sm:px-6 lg:px-8">
      <!-- Your content -->
      <div class="container">
    <!-- Direct to Add Product -->
    <form action="add_product.php" method="get">
        <button type="submit" class="btn btn-success" name="add">Add Product</button>
    </form>
    <br>

    <!-- Search Engine -->
    <form action="" method="post">
        <input type="text" name="search" placeholder="Search..." size="50" autofocus autocomplete="off" id="keyword" class="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6">
        <button type="submit" name="find" id="cari">Find</button>
        <img src="../assets/loader.gif" alt="" class="loader">
    </form>
    <br>
    <!-- Navigation -->
    <?php for($i = 1; $i <= $amountPage; $i++): ?>
        <button type="button" class="btn btn-outline-warning"><a href="?p=<?=$i;?>"><?= $i;?></a></button>
    <?php endfor;?>
    <br>
    <div id="container">
        <table class="table table-bordered border-primary">
            <tr>
                <th>No.</th>
                <th>Action</th>
                <th>No_Seri</th>
                <th>Nama_Produk</th>
                <th>Jenis</th>
                <th>Harga</th>
                <th>Gambar</th>
            </tr>
            <?php $i = 1 ;?>
            <?php foreach($produk as $item):?>
            <tr>
                <td><?= $i;?></td>
                <td>
                    <!-- Direct to update Product -->
                    <form action="update_product.php" method="post" style="display:inline-block;">
                        <input type="hidden" name="no_seri" value="<?= $item["no_seri"];?>">
                        <button type="submit" class="btn btn-warning update" onclick="return confirm('Are you sure?');">Update</button>
                    </form>

                    <!-- Direct to update Product -->
                    <form action="delete_product.php" method="post" style="display:inline-block;">
                        <input type="hidden" name="no_seri" value="<?= $item["no_seri"];?>">
                        <button type="submit" class="btn btn-danger delete" onclick="return confirm('Are you sure?');">Delete</button>
                    </form>
                </td>
                <td><?= $item["no_seri"];?></td>
                <td><?= $item["nama_produk"];?></td>
                <td><?= $item["jenis"];?></td>
                <td><?= $item["harga"];?></td>
                <td><img src="../tmp/<?= $item["gambar"];?>" alt="<?= $item["gambar"];?>" width="50"></td>
            </tr>
            <?php $i++;?>
            <?php endforeach;?>
        </table>
        </div>
        <br>
        <button type="button" class="btn btn-secondary"><a href="../index.php" style="text-decoration: none;">Back to Home</a></button>

    </div>
    </div>
  </main>
</div>
</body>
</html>



