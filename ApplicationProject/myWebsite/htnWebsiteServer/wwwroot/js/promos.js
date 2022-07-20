window.onload = function() {

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