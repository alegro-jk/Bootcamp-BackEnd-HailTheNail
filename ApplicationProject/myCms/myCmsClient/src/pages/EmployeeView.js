import React from "react";
import './EmployeeView.css';
import twicelogo1 from "../media/twice.jpg";
import logo from "../media/logo.jpg"
import { Link } from 'react-router-dom';


function EmployeeView()
{

    // constructor (props) {
    //     super(props)
    //     this.state = {
    //         human: ""
    //     }
    // }

    // render() {
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
                    <img src={twicelogo1} id="twicelogo1" alt="twicelogo1"/>
                </div>
            </div>
        </div>
        </>
        )
    }
// }

export default EmployeeView;
