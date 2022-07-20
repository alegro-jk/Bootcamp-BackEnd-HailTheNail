window.onload = function() {

    var logo_home = document.getElementById('logo_home');
    if(logo_home) {
        logo_home.onclick = function() {
        { document.location = "htn.html" }
        }
    }

    var menulink = document.getElementById('menulink');
    var menu = document.getElementById('menu');

    menulink.onclick = function() {
        if(menu.style.display == "none") {
            menu.style.display = "block";
        }
        else {
            menu.style.display = "none";
        }
    }

}