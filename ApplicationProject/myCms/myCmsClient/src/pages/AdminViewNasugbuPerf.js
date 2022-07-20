import React, { useState, useEffect } from "react";
import './AdminView.css';
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';



function AdminViewNasugbuPerf()
{
    // KIM
   const [data1, setData1] = useState([]);
   const [order1, setOrder1] = useState("ASC");

    const sorting1 = (col) => {
        if(order1 === "ASC") {
            const sorted = [...data1].sort((a,b) =>
                a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1 
            );
            setData1(sorted);
            setOrder1("DSC");
        }
        if(order1 === "DSC") {
            const sorted = [...data1].sort((a,b) =>
                a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1 
            );
            setData1(sorted);
            setOrder1("ASC");
        }
    }

    const sortingNum1 = (col) => {
        if(order1 === "ASC") {
            const sorted = [...data1].sort((a,b) =>
                a[col] > b[col] ? 1 : -1 
            );
            setData1(sorted);
            setOrder1("DSC");
        }
        if(order1 === "DSC") {
            const sorted = [...data1].sort((a,b) =>
                a[col] < b[col] ? 1 : -1 
            );
            setData1(sorted);
            setOrder1("ASC");
        }
    }

   const apiGetKim = () => {
       fetch("/summary/nasugbu/kim")
       .then((response) => response.json())
       .then((json) => {
           console.log(json);
           setData1(json);
           setTotalGuest1(json[0].guestNumber)
       });
   };

   useEffect(() => {
       apiGetKim();
   }, []);

   const[guestNumber1, setTotalGuest1] = useState(0);
   var[total1, Total1] = useState(0);

    function getTotal1(guestNumber1) {
        total1 += guestNumber1;
        // console.log(total);
    }

   // SON
   const [data2, setData2] = useState([]);
   const [order2, setOrder2] = useState("ASC");

    const sorting2 = (col) => {
        if(order2 === "ASC") {
            const sorted = [...data2].sort((a,b) =>
                a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1 
            );
            setData2(sorted);
            setOrder2("DSC");
        }
        if(order2 === "DSC") {
            const sorted = [...data2].sort((a,b) =>
                a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1 
            );
            setData2(sorted);
            setOrder2("ASC");
        }
    }

    const sortingNum2 = (col) => {
        if(order2 === "ASC") {
            const sorted = [...data2].sort((a,b) =>
                a[col] > b[col] ? 1 : -1 
            );
            setData2(sorted);
            setOrder2("DSC");
        }
        if(order2 === "DSC") {
            const sorted = [...data2].sort((a,b) =>
                a[col] < b[col] ? 1 : -1 
            );
            setData2(sorted);
            setOrder2("ASC");
        }
    }

   const apiGetSon = () => {
    fetch("/summary/nasugbu/son")
    .then((response) => response.json())
    .then((json) => {
        console.log(json);
        setData2(json);
        setTotalGuest2(json[0].guestNumber)
    });
};

useEffect(() => {
    apiGetSon();
}, []);

const[guestNumber2, setTotalGuest2] = useState(0);
   var[total2, Total2] = useState(0);

    function getTotal2(guestNumber2) {
        total2 += guestNumber2;
        // console.log(total);
    }

// HIRAI
const [data3, setData3] = useState([]);
   const [order3, setOrder3] = useState("ASC");

    const sorting3 = (col) => {
        if(order3 === "ASC") {
            const sorted = [...data3].sort((a,b) =>
                a[col].toLowerCase() > b[col].toLowerCase() ? 1 : -1 
            );
            setData3(sorted);
            setOrder3("DSC");
        }
        if(order3 === "DSC") {
            const sorted = [...data3].sort((a,b) =>
                a[col].toLowerCase() < b[col].toLowerCase() ? 1 : -1 
            );
            setData3(sorted);
            setOrder3("ASC");
        }
    }

    const sortingNum3 = (col) => {
        if(order3 === "ASC") {
            const sorted = [...data3].sort((a,b) =>
                a[col] > b[col] ? 1 : -1 
            );
            setData3(sorted);
            setOrder3("DSC");
        }
        if(order3 === "DSC") {
            const sorted = [...data3].sort((a,b) =>
                a[col] < b[col] ? 1 : -1 
            );
            setData3(sorted);
            setOrder3("ASC");
        }
    }

    const apiGetChou = () => {
        fetch("/summary/nasugbu/chou")
        .then((response) => response.json())
        .then((json) => {
            console.log(json);
            setData3(json);
            setTotalGuest3(json[0].guestNumber)
        });
    };

    useEffect(() => {
        apiGetChou();
    }, []);

    const[guestNumber3, setTotalGuest3] = useState(0);
   var[total3, Total3] = useState(0);

    function getTotal3(guestNumber3) {
        total3 += guestNumber3;
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
                    <h1 id='title'>NASUGBU Staffs Performance</h1>
                    <h2>• KIM DAHYUN</h2>
                    <table id='table'>
                    <tbody>
                        <tr>
                        <th>ID<button onClick={()=>sortingNum1("id")}>↕</button></th>    
                            <th>DATE<button onClick={()=>sorting1("dateOfVisit")}>↕</button></th>    
                            <th>SERVICES</th>    
                            <th>NO. OF GUESTS<button onClick={()=>sortingNum1("guestNumber")}>↕</button></th>    
                            <th>TOTAL NO. OF GUESTS ATTENDED</th>       
                        </tr>
                        {data1.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.dateOfVisit}</td>
                                <td>{item.availServices}</td>
                                <td>{item.guestNumber}</td>
                                <td>{getTotal1(item.guestNumber)}{total1}</td>
                            </tr>
                            
                        ))}
                    </tbody>
                    </table>
                            <br></br><br></br>
                    <h2>• SON CHAEYOUNG</h2>
                    <table id='table'>
                    <tbody>
                        <tr>
                        <th>ID<button onClick={()=>sortingNum2("id")}>↕</button></th>    
                            <th>DATE<button onClick={()=>sorting2("dateOfVisit")}>↕</button></th>    
                            <th>SERVICES</th>    
                            <th>NO. OF GUESTS<button onClick={()=>sortingNum2("guestNumber")}>↕</button></th>    
                            <th>TOTAL SERVICES DONE</th>       
                        </tr>
                        {data2.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.dateOfVisit}</td>
                                <td>{item.availServices}</td>
                                <td>{item.guestNumber}</td>
                                <td>{getTotal2(item.guestNumber)}{total2}</td>
                            </tr>
                            
                        ))}
                    </tbody>
                    </table>
                            <br></br><br></br>
                    <h2>• CHOU TZUYU</h2>
                    <table id='table'>
                    <tbody>
                        <tr>
                        <th>ID<button onClick={()=>sortingNum3("id")}>↕</button></th>    
                            <th>DATE<button onClick={()=>sorting3("dateOfVisit")}>↕</button></th>    
                            <th>SERVICES</th>    
                            <th>NO. OF GUESTS<button onClick={()=>sortingNum3("guestNumber")}>↕</button></th>    
                            <th>TOTAL SERVICES DONE</th>       
                        </tr>
                        {data3.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.dateOfVisit}</td>
                                <td>{item.availServices}</td>
                                <td>{item.guestNumber}</td>
                                <td>{getTotal3(item.guestNumber)}{total3}</td>
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

export default AdminViewNasugbuPerf;
