<?php 
require "../module/module.php";
$keyword = $_GET["keyword"]; 
$query = "SELECT * FROM produk 
            WHERE 
            nama_produk LIKE '%$keyword%' OR
            no_seri LIKE '%$keyword%' OR 
            jenis LIKE '%$keyword%' OR
            harga LIKE '$$keyword$';
            ";
$produk = query($query);
?>

<table border="1" cellspacing="0" cellpadding="10">
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
                    <form action="update_product.php" method="post">
                        <input type="hidden" name="no_seri" value="<?= $item["no_seri"];?>">
                        <button type="submit" name="update" onclick="return confirm('Are you sure?');">Update</button>
                    </form>

                    <!-- Direct to update Product -->
                    <form action="delete_product.php" method="post">
                        <input type="hidden" name="no_seri" value="<?= $item["no_seri"];?>">
                        <button type="submit" name="update" onclick="return confirm('Are you sure?');">Delete</button>
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
        <br>