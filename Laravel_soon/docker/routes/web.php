<?php

use App\Http\Controllers\PostController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;


Route::view('/', 'welcome');
Route::resource('/posts', PostController::class);











// Route::get('/posts', [PostController::class,'index'])->name('post.index');
// Route::get('/posts/create', [PostController::class,'create']);
// Route::post('/posts', [PostController::class,'store']);
// Route::get('/posts{id}', [PostController::class,'show']);
// Route::get('/posts/{id}/edit', [PostController::class,'edit']);
// Route::put('/posts{id}', [PostController::class,'update']);
// Route::delete('/posts/{id}', [PostController::class,'destroy']);


