<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>{{ $header }}</title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body>
    {{-- navbar --}}
    <x-navbar />

    {{-- header --}}
    <header class="bg-white shadow">
        <div class="mx-auto max-w-7xl px-4 py-6 sm:px-6 lg:px-8">
          <h1 class="text-3xl font-bold tracking-tight text-gray-900">{{ $header }}</h1>
        </div>
    </header>
    
    <main>
        <div class="mx-auto max-w-7xl px-4 py-6 sm:px-6 lg:px-8">
          <!-- Your content -->
          {{ $slot }}
        </div>
    </main>
</body>
</html>
