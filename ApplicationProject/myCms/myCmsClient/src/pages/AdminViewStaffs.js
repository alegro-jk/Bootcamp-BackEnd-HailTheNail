import React, { useState, useEffect } from "react";
import './AdminView.css';
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';

function AdminViewStaffs()
{

    const [data, setData] = useState([]);
    const [order, setOrder] = useState("ASC");

    const apiGet = () => {
        fetch("/staffs")
        .then((response) => response.json())
        .then((json) => {
            console.log(json);
            setData(json);
        });
    };

    useEffect(() => {
        apiGet();
    }, []);

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

    async function handleAddSubmit(e) {
        e.preventDefault();
        const form = new FormData(document.getElementById('addItem'));
        const response = await fetch('/staffs', {
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
            alert("New staff has been added!");
            var item = document.getElementById('item');
            item.style.display = 'none';
            // window.location.reload(true);
            apiGet();
        }
    }
    async function handleDelete(id) {
        if(window.confirm("Are you sure you want to delete this staff from the database?")) {
            const response = await fetch('/staffs/'+id, {
                method: 'DELETE',
                headers: {
                'Content-Type': 'application/json',
                'X-ApiKey' : 'MyPasswordIsLong'
                },
            });
            if(response.status === 401) {
                alert("Unauthorized access!");
            }
            // window.location.reload(false);
            apiGet();
        }
    }

    return (
    <>
    <div id="hdr">
        <div className="header">
            <img src={logo} id="hdrlogo" alt="hdrlogo"/>
            <span id="greeting">Hello, our dearest <b><i>Admin</i></b>!</span>
        </div>
        <div className="body">
            <div className="sidebar">
            <div className="store">
                   <h1><b>STORE INFO</b></h1>
                   <a href="javascript:void(0)" id="info"><Link to="/adminview_staffs" style={{ textDecoration: "none", color: "black" }} >• STAFFS</Link></a><br></br>
                   <a href="javascript:void(0)" id="info"><Link to="/adminview_promos" style={{ textDecoration: "none", color: "black" }} >• PROMOS</Link></a><br></br>
                   <a href="javascript:void(0)" id="info"><Link to="/adminview_branches" style={{ textDecoration: "none", color: "black" }} >• BRANCHES</Link></a><br></br>
                   <a href="javascript:void(0)" id="info"><Link to="/adminview_guests" style={{ textDecoration: "none", color: "black" }} >• GUESTS</Link></a><br></br>
               </div><br></br>
               <div className="reports">
                   <h1><b>REPORTS</b></h1>
                   <a href="javascript:void(0)" id="info"><Link to="/adminview_overall" style={{ textDecoration: "none", color: "black" }} >• OVERALL INCOME</Link></a><br></br>
                       <h2><b>SILANG BRANCH</b></h2>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_silang_income" style={{ textDecoration: "none", color: "black" }} >• INCOME and BOOKINGS</Link></a><br></br>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_silang_staff_performance" style={{ textDecoration: "none", color: "black" }} >• STAFF PERFORMANCE</Link></a><br></br>
                       <h2><b>GENTRI BRANCH</b></h2>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_gentri_income" style={{ textDecoration: "none", color: "black" }} >• INCOME and BOOKINGS</Link></a><br></br>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_gentri_staff_performance" style={{ textDecoration: "none", color: "black" }} >• STAFF PERFORMANCE</Link></a><br></br>
                       <h2><b>NASUGBU BRANCH</b></h2>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_nasugbu_income" style={{ textDecoration: "none", color: "black" }} >• INCOME and BOOKINGS</Link></a><br></br>
                           <a href="javascript:void(0)" id="info"><Link to="/adminview_nasugbu_staff_performance" style={{ textDecoration: "none", color: "black" }} >• STAFF PERFORMANCE</Link></a>
               </div><br></br><br></br><br></br><br></br><br></br>
            <div>
                    <button id="logout"><Link to="/" style={{ textDecoration: "none" }} >LOGOUT</Link></button><br></br>
                </div>   
            </div>   
            <div className="content">
                <div>
                    <h1 id='title'>Staffs</h1>
                    <table id='table'>
                    <tbody>
                        <tr>
                            <th>ID<button onClick={()=>sortingNum("id")}>↕</button></th>    
                            <th>NAME<button onClick={()=>sorting("name")}>↕</button></th>    
                            <th>AGE<button onClick={()=>sorting("age")}>↕</button></th>    
                            <th>BRANCH<button onClick={()=>sorting("branch")}>↕</button></th>    
                            <th>METHOD</th>
                        </tr>
                        {data.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td>{item.age}</td>
                                <td>{item.branch}</td>
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
                            <h2>• ADD STAFF</h2>
                            <br></br>
                            <form id='addItem' onSubmit={handleAddSubmit}>
                                <p>NAME</p>
                                <input type='text' className='addName' id='addName' name='Name' />
                                <p>AGE</p>
                                <input type='text' className='addAge' id='addAge' name='Age' />
                                <p>BRANCH</p>
                                <input type='text' className='addBranch' id='addBranch' name='Branch' />
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

export default AdminViewStaffs;
