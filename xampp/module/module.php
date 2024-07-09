<?php 
//Get database pada port localhost 3307
$db = mysqli_connect(
    'localhost:3307', 
    'root', 
    '',
    'iot');
//Procedure data user
function query($query){
    global $db;
    $result = mysqli_query($db, $query);
    $records = [];
    while($record = mysqli_fetch_assoc($result)){
        $records[] = $record;
    }
    return $records;
}

function tambah($data){
    global $db;
    // Prepare the SQL statement
    $no_seri = htmlspecialchars($data["no_seri"]);
    $nama_produk = htmlspecialchars($data["nama_produk"]);
    $jenis = htmlspecialchars($data["jenis"]);
    $harga = htmlspecialchars($data["harga"]);
    
    //Upload Gambar
    $gambar = upload();
    if(!$gambar){
        return false;
    }

    $insert = "INSERT INTO produk VALUES
    ('$no_seri', '$nama_produk', '$jenis', '$harga', '$gambar')";
     
    // Execute the query
    mysqli_query($db, $insert);

    return mysqli_affected_rows($db);
}

function upload(){
    $name = $_FILES['gambar']['name'];
    $size = $_FILES['gambar']['size'];
    $error = $_FILES['gambar']['error'];
    $tmp = $_FILES['gambar']['tmp_name'];

    //cek upload none
    if($error == 4){
        echo "<script>
                alert('choose image!');
              </script>
              ";
        return false; 
    }
    //cek ekstensi file
    $extensionValid = ['jpg', 'jpeg', 'png'];
    $extensionImg = explode('.', $name);
    $extension = strtolower(end($extensionImg));
    if(!in_array($extension, $extensionValid)){
        echo "<script>
                alert('yang di upload bukan gambar!');
              </script>
              ";
        return false; 
    }

    //cek ukuran
    if($size > 1000000){
        echo "<script>
        alert('Ukuran gambar terlalu besar!');
      </script>
      ";
return false; 
    }

    //gambar siap diupload
    //generate name
    $newName = uniqid();
    $newName .= ".".$extension;
    var_dump($newName);
    move_uploaded_file($tmp, '../tmp/'.$newName);
    return $newName;
}

//Delete Product
function delete($i){
    global $db;
    mysqli_query($db, "DELETE FROM produk WHERE no_seri = '$i'");

    return mysqli_affected_rows($db);
}

function update($data){
    global $db;
    // Prepare the SQL statement
    $no_seri = htmlspecialchars($data["no_seri"]);
    $nama_produk = htmlspecialchars($data["nama_produk"]);
    $jenis = htmlspecialchars($data["jenis"]);
    $harga = htmlspecialchars($data["harga"]);
    $gambarLama = htmlspecialchars($data["gambarLama"]);

    //USER PILIH GAMBAR BARU?
    if($_FILES["gambar"]['error'] === 4){
        $gambar = $gambarLama;
    }else{
        $gambar = upload();
    }

    $update = "UPDATE produk SET
                no_seri = '$no_seri',
                nama_produk = '$nama_produk',
                jenis = '$jenis',
                harga = '$harga',
                gambar = '$gambar'
                WHERE no_seri = '$no_seri'
                ";
     
    // Execute the query
    mysqli_query($db, $update);

    return mysqli_affected_rows($db);
}

function find($search){
    $query = "SELECT * FROM produk 
                WHERE 
                nama_produk LIKE '%$search%' OR
                no_seri LIKE '%$search%' OR 
                jenis LIKE '%$search%' OR
                harga LIKE '$$search$';
            ";
            return query($query); 
}

//Register
function register($data){
    global $db;

    $name = strtolower(stripcslashes($data["name"]));
    $username = strtolower(stripcslashes($data["username"]));
    $password = mysqli_real_escape_string($db, $data["password"]);
    $rePassword = mysqli_real_escape_string($db, $data["rePassword"]);

    //cek username
    $isUser = mysqli_query($db,"SELECT username FROM users WHERE username='$username' ");
    if(mysqli_fetch_assoc($isUser))
    {
        echo "<script>
        alert('Username had register');
      </script>";
      return false;
    }

    // Konfirmasi password
    if($password !== $rePassword){
        echo "<script>
                alert('Password not matched');
              </script>";
        return false;
    }
    //Encrypt password
    $password = password_hash($password, PASSWORD_DEFAULT);
    var_dump($password);

    //Add user account
    mysqli_query($db,"INSERT INTO users VALUES('', '$name', '$username', '$password')");

    return mysqli_affected_rows($db);
}

?>