import React, { useState, useEffect } from "react";
import './AdminView.css';
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';



function AdminViewSilangIncome()
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
       fetch("/summary/silang")
       .then((response) => response.json())
       .then((json) => {
           console.log(json);
           setData(json);
           setTotalAmount(json[0].totalamount)
       });
   };

   useEffect(() => {
       apiGet();
   }, []);

   const[guestNumber, setTotalGuest] = useState(0);
   var[total, Total] = useState(0);

    function getTotal(guestNumber) {
        total += guestNumber;
        // console.log(total);
    }

    const[totalamount, setTotalAmount] = useState(0);
   var[total1, Total1] = useState(0);

    function getTotal1(totalamount) {
        total1 += totalamount;
        // console.log(total);
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
                    <h1 id='title'>SILANG Summary Report</h1>
                    <table id='table'>
                    <tbody>
                        <tr>
                        <th>ID<button onClick={()=>sortingNum("id")}>↕</button></th>    
                            <th>DATE<button onClick={()=>sorting("dateOfVisit")}>↕</button></th>    
                            <th>SERVICES<button onClick={()=>sorting("availServices")}>↕</button></th>    
                            <th>NO. OF GUESTS<button onClick={()=>sortingNum("guestNumber")}>↕</button></th>    
                            <th>TOTAL # OF BOOKINGS</th>       
                            <th>PRODUCTS<button onClick={()=>sorting("availProducts")}>↕</button></th>    
                            <th>TOTAL (₱) <button onClick={()=>sortingNum("totalamount")}>↕</button></th>       
                            <th>GENERAL TOTAL (₱)</th>       
                        </tr>
                        {data.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.dateOfVisit}</td>
                                <td>{item.availServices}</td>
                                <td>{item.guestNumber}</td>
                                <td>{getTotal(item.guestNumber)}{total}</td>
                                <td>{item.availProducts}</td>
                                <td>{item.totalamount}</td>
                                <td>{getTotal1(item.totalamount)}{total1}</td>
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

export default AdminViewSilangIncome;
