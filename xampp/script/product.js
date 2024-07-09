// const keyword = document.getElementById('keyword');
// const cari = document.getElementById('cari'); 
// const container = document.getElementById('container');


// keyword.addEventListener('keypress', function(){
//     //objek ajax
//     let xhr = new XMLHttpRequest();

//     //check ajax ready
//     xhr.onreadystatechange = function(){
//         if(xhr.readyState == 4 && xhr.status == 200){
//             container.innerHTML = xhr.responseText;
//         }
//     }

//     //eksekusi ajax
//     xhr.open('GET', '../ajax/produk.php?keyword=' + keyword.value, true);
//     xhr.send();
// });

$(document).ready(function(){
    $('#cari').hide();
    
    $('#keyword').on('keyup', function(){
        //munculkan loading
        $('.loader').show();
        $.get('../ajax/produk.php?keyword=' + $('#keyword').val(), function(data){
            $('container').html(data);
            $('.loader').hide();
        });
        // $('#container').load('../ajax/produk.php?keyword=' + $('#keyword').val());
    });
});