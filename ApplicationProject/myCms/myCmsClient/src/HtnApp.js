import React from "react";
import './HtnApp.css';
import logo from "./media/logo.jpg"
import { useNavigate } from "react-router-dom";

function HtnApp()
{
    let navigate = useNavigate();

    async function handleSubmit(e) {
        e.preventDefault();
        const data = new FormData(document.getElementById("form"));
        const response = await fetch('/sessions', {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json'
            },
            body: JSON.stringify(Object.fromEntries(data.entries()))
            });
            
        if(response.status == 401)
        {
            alert("Unauthorized access!");
        }
        else if (response.status == 200)
        {
            var jsonData = await response.json();
            if(jsonData.type === "Admin")
            {
                alert("Logging in as an Admin!");
                navigate("/adminview", { replace: true });
            }
            else
            {
                alert("Logging in as an Employee!");
                navigate("/employeeview", { replace: true });
            }
        }
        else
        {
            alert(response.status);
        }
    }

    const enterSubmit = (event) => {
        var validUsername = document.getElementById("Username").value;
        var validPassword = document.getElementById("Password").value;
        if(validUsername === "" || validPassword === "") {
            alert("Login failed! Please enter a valid username and password.");
            event.preventDefault();
        }
    }

    return (
    <>
    <div>
        <center>
            <img src={logo} id="logoId" alt="logo"/>
        </center>
        <center>
        <form id="form" onSubmit={handleSubmit}>
            <br></br><input type="text" 
            onkeypress={event => (event.charCode > 64 && event.charCode < 91) || (event.charCode > 96 && event.charCode < 123) || (event.charCode==32)}
            id="Username" name="Username" placeholder="Enter username here:" /><br></br>

            <br></br><input type="password" 
            onkeypress={event => (event.charCode > 64 && event.charCode < 91) || (event.charCode > 96 && event.charCode < 123) || (event.charCode==32)}
            id="Password" name="Password" placeholder="Enter password here:" /><br></br>

            <input type="submit" id="submit" name="submit" value="LOGIN" style={{ textDecoration: "none", color: "black" }}  onClick={enterSubmit}/>
        </form></center>
    </div>
    </>
    );
}

export default HtnApp;
