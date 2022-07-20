window.onload = function() {

    var picture = 0;
    changePic();
    function changePic() {
        var images = document.getElementsByClassName('changepic');
        for(var n=0; n < images.length; n++) {
            images[n].style.display = "none";
            }
            picture++;
            if(picture > images.length) {picture =1} images[picture-1].style.display = "block";
            setTimeout(changePic, 4000);
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