<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Contact;

class ContactController extends Controller
{
    public function index(){
        $contacts = Contact::all();
        return view('contact.index', ['contacts' => $contacts]);
    }

    public function create(){
        return view('contact.create');
    }

    public function store(Request $request){
        $data = $request->validate([
            'name' => 'required',
            'age' => 'required|numeric',
            'role' => 'required',
            'phone_number' => 'required|numeric',
            'email' => 'required|email|unique:contacts,email',
        ]);

        $newContact = Contact::create($data);
        
        // // Debugging: cek apakah data berhasil disimpan
        // dd($newContact);

        return redirect(route('contact.index'));
    }
}
