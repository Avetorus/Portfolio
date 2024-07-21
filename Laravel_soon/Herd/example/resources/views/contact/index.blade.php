<x-layout>
    <x-slot:header>
        Contact
    </x-slot:header>
    <button type="button" class="focus:outline-none text-white bg-yellow-400 hover:bg-yellow-500 focus:ring-4 focus:ring-yellow-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:focus:ring-yellow-900"><a href="/contact/create">Add Contact</a></button>
    <ul role="list" class="divide-y divide-gray-100">
      @foreach($contacts as $contact)
        <li class="flex justify-between gap-x-6 py-5">
          <div class="flex min-w-0 gap-x-4">
            <img class="h-12 w-12 flex-none rounded-full bg-gray-50" src="https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="">
            <div class="min-w-0 flex-auto">
              <p class="text-sm font-semibold leading-6 text-gray-900">{{ $contact->name }}</p>
              <p class="mt-1 truncate text-xs leading-5 text-gray-500">{{ $contact->email }}</p>
            </div>
          </div>
          <div class="hidden shrink-0 sm:flex sm:flex-col sm:items-end">
            <p class="text-sm leading-6 text-gray-900">{{ $contact->role }}</p>
            <p class="mt-1 text-xs leading-5 text-gray-500">Last seen <time datetime="2023-01-23T13:23Z">3h ago</time></p>
          </div>
        </li>
      @endforeach
      </ul>
</x-layout>