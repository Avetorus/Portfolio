<?php

use App\Http\Controllers\ContactController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('home');
}); 

Route::get('/product', function () {
    return view('product');
});


//Route for Contact
Route::get('/contact', [ContactController::class, 'index'])->name('contact.index');

Route::get('/contact/create', [ContactController::class, 'create'])->name('contact.create');

Route::post('/contact', [ContactController::class, 'store'])->name('contact.store');