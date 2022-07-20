import React, { useState, useEffect } from "react";
import './EmployeeView.css';
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';

function EmpViewSilangServices()
{
    const [data, setData] = useState([]);
    const [order, setOrder] = useState("ASC");

    const sorting = (col) => {
        if(order === "ASC") {
            const sorted = [...data].sort((a,b) =>
                a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1 
            );
            setData(sorted);
            setOrder("DSC");
        }
        if(order === "DSC") {
            const sorted = [...data].sort((a,b) =>
                a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1 
            );
            setData(sorted);
            setOrder("ASC");
        }
    }

    const sortingNum = (col) => {
        if(order === "ASC") {
            const sorted = [...data].sort((a,b) =>
                a[col] > b[col] ? 1 : -1 
            );
            setData(sorted);
            setOrder("DSC");
        }
        if(order === "DSC") {
            const sorted = [...data].sort((a,b) =>
                a[col] < b[col] ? 1 : -1 
            );
            setData(sorted);
            setOrder("ASC");
        }
    }

    const apiGet = () => {
        fetch("/services")
        .then((response) => response.json())
        .then((json) => {
            console.log(json);
            setData(json);
        });
    };

   useEffect(() => {
       apiGet();
   }, []);

   async function handleAddSubmit(e) {
    e.preventDefault();
    const form = new FormData(document.getElementById('addItem'));
    const response = await fetch('/services', {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        'X-ApiKey' : 'MyPasswordIsLong'
        },
        body: JSON.stringify(Object.fromEntries(form.entries()))
        });
        if(response.status === 401) {
            alert("Unauthorized access!");
        }
        if(response.status === 200) {
            alert("New service has been added!");
            var item = document.getElementById('item');
            item.style.display = 'none';
            apiGet();
            // window.location.reload(true);
        }
    }
    async function handleDelete(id) {
        if(window.confirm("Are you sure you want to delete this service from the database?")) {
            const response = await fetch('/services/'+id, {
                method: 'DELETE',
                headers: {
                'Content-Type': 'application/json',
                'X-ApiKey' : 'MyPasswordIsLong'
                },
            });
            if(response.status === 401) {
                alert("Unauthorized access!");
            }
            apiGet();
            // window.location.reload(false);
        }
    }

   return (
    <>
    <div id="hdr">
            <div className="header">
                <img src={logo} id="hdrlogo" alt="hdrlogo"/>
                <span id="greeting">Hello, our dearest <b><i>Employee</i></b>!</span>
            </div>
            <div className="body">
                <div className="sidebar">
                    <div className="store">
                        <h1><b>STORE INFO</b></h1>
                            <h2><b>SILANG BRANCH</b></h2>
                                <a href="#" id="info"><Link to="/empview_silang_services" style={{ textDecoration: "none", color: "black" }} >• SERVICES</Link></a><br></br>
                                <a href="#" id="info"><Link to="/empview_silang_products" style={{ textDecoration: "none", color: "black" }} >• PRODUCTS</Link></a><br></br>
                            <h2><b>GENTRI BRANCH</b></h2>
                                <a href="#" id="info"><Link to="/empview_gentri_services" style={{ textDecoration: "none", color: "black" }} >• SERVICES</Link></a><br></br>
                                <a href="#" id="info"><Link to="/empview_gentri_products" style={{ textDecoration: "none", color: "black" }} >• PRODUCTS</Link></a><br></br>
                            <h2><b>NASUGBU BRANCH</b></h2>
                                <a href="#" id="info"><Link to="/empview_nasugbu_services" style={{ textDecoration: "none", color: "black" }} >• SERVICES</Link></a><br></br>
                                <a href="#" id="info"><Link to="/empview_nasugbu_products" style={{ textDecoration: "none", color: "black" }} >• PRODUCTS</Link></a><br></br>
                        </div><br></br><br></br>
                    <div className="others">
                        <h2><b>OTHERS</b></h2>
                        <a href="#" id="info"><Link to="/empview_promos" style={{ textDecoration: "none", color: "black" }} >• PROMOS</Link></a><br></br>
                        <a href="#" id="info"><Link to="/empview_whatsnew" style={{ textDecoration: "none", color: "black" }} >• WHAT'S NEW</Link></a><br></br>

                    </div><br></br><br></br><br></br>
                    <div>
                        <button id="logout"><Link to="/" style={{ textDecoration: "none" }} >LOGOUT</Link></button><br></br>
                    </div>     
                </div>
            <div className="content">
                <div>
                    <h1 id='title'>SILANG SERVICES</h1>
                    <table id='table'>
                    <tbody>
                        <tr>
                            <th>ID<button onClick={()=>sortingNum("id")}>↕</button></th>    
                            <th>NAME<button onClick={()=>sorting("name")}>↕</button></th>
                            <th>PRICE<button onClick={()=>sortingNum("price")}>↕</button></th>
                            <th>METHOD</th>
                        </tr>
                        {data.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td>{item.price}</td>
                                <td>
                                    <button type='button' className='delete' id="deleteItem" onClick={e=> {e.preventDefault(); handleDelete(item.id)}}>Delete</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                    </table>
                    <br></br><br></br>
                    <div id='item'>
                        <div>
                            <h2>• ADD SERVICE</h2>
                            <br></br>
                            <form id='addItem' onSubmit={handleAddSubmit}>
                                <p>Name</p>
                                <input type='text' className='addName' id='addName' name='Name' />
                                <p>Price</p>
                                <input type='text' className='addPrice' id='addPrice' name='Price' />
                                <br></br>
                                <button type='submit' name='Add' value='Add' className='addbtn'>Add</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </>
    )
}

export default EmpViewSilangServices;
