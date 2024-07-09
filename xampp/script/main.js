//Animation Typed
let typed = new Typed(".text", {
    strings:["Frontend Developer", "Backend Developer", "Fullstack Developer"],
    typeSpeed: 100,
    backSpeed: 100,
    backDelay: 1000,
    loop:true
});

//Dropdown User
let menu = document.getElementById("subMenu");
function toggleMenu(){
    menu.classList.toggle("open-menu");
}