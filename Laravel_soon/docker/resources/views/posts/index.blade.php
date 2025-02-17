<x-layout>
    <x-header>Posts Index Page</x-header>
    <section>
        <div class="flex justify-end">
            <a href="/posts/create"
            class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">Create</a>
        </div>
    </section>
    <div>Here is {{ $name }} and the age is {{ $age }}</div>
    <ul>
        @foreach ($posts as $post)
            <li><a href="/posts/{{ $post }}">{{ $post }}</a></li>
        @endforeach
    </ul>
</x-layout>