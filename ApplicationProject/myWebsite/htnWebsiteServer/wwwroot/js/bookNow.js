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

    var today = new Date().toISOString().split('T')[0];
    document.getElementsByName("day_visit")[0].setAttribute('min', today);

}

    function formdata() {
        var fname= document.getElementById("fname").value;
        var lname= document.getElementById("lname").value;
        var email= document.getElementById("email").value;
        var phone= document.getElementById("phone").value;
        var contact= document.getElementsByClassName("pref_contact").value;
        var serv= document.getElementsByClassName("serv");
        var prods= document.getElementsByClassName("prods");
        var pref_branch= document.getElementsByClassName("branchh").value;
        var pref_tech= document.getElementsByClassName("techni").value;
        var day_visit= document.getElementById("day_visit").value;
        var time= document.getElementsByClassName("visit_time").value;
        var guest= document.getElementById("guest").value;
        var req= document.getElementById("req").value;

        if(fname == "" || lname == "" || email == "" || phone == "" 
        || contact == "" || serv == "" || prods == "" || pref_tech == "" 
        || pref_branch == "" || day_visit == "" || guest == "" || time == "" 
        || req == "") {
            alert("Please fill out all the needed information.");
            // window.location = "/bookNow";
        }
        else {
            alert("Confirm all details?")
        }
    }