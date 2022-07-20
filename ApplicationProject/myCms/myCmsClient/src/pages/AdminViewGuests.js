import React, { useState, useEffect } from "react";
import './AdminView.css';
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';



function AdminViewGuests() 
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
        fetch("/summary")
        .then((response) => response.json())
        .then((json) => {
            console.log(json);
            setData(json);
        });
    };

    useEffect(() => {
        apiGet();
    }, []);

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
                    <h1 id='title'>Summary of Guests</h1>
                    <table id='table'>
                    <tbody>
                        <tr>
                            <th>ID<button onClick={()=>sortingNum("id")}>↕</button></th>  
                            <th>ORDER DATE<button onClick={()=>sorting("orderdate")}>↕</button></th>    
                            <th>VISIT DATE<button onClick={()=>sorting("dateOfVisit")}>↕</button></th>  
                            <th>FIRST NAME</th>    
                            <th>LAST NAME<button onClick={()=>sorting("lastName")}>↕</button></th>    
                            <th>EMAIL</th>    
                            <th>PHONE NUMBER</th>    
                            <th>CONTACT VIA:<button onClick={()=>sorting("methodOfContact")}>↕</button></th>    
                            <th>BRANCH<button onClick={()=>sorting("preferredBranch")}>↕</button></th>
                            <th># of GUESTS<button onClick={()=>sortingNum("guestNumber")}>↕</button></th>
                            <th>STAFF<button onClick={()=>sorting("preferredTechnician")}>↕</button></th>    
                            <th>REQUEST</th>    
                        </tr>
                        {data.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.orderdate}</td>
                                <td>{item.dateOfVisit}</td>
                                <td>{item.firstName}</td>
                                <td>{item.lastName}</td>
                                <td>{item.email}</td>
                                <td>{item.phoneNumber}</td>
                                <td>{item.methodOfContact}</td>
                                <td>{item.preferredBranch}</td>
                                <td>{item.guestNumber}</td>
                                <td>{item.preferredTechnician}</td>
                                <td>{item.request}</td>
                            </tr>
                        ))}
                    </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </>
    )
}

export default AdminViewGuests;
