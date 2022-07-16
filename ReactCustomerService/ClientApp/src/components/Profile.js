import React, { useState, useEffect } from 'react';
import './Profile.css';
import QuantityBalanceComponant from './QuantityBalanceComponant';
import homeservice from "../services/homeservices";
import { useAuthContext } from "@asgardeo/auth-react";



const Profile = () => {

    const [MobileNumberData, setMobileNumberData] = useState([]);
    const [QuantityBalance, setQuantityBalance] = useState([]);
    const [Invoice, setInvoice] = useState([]);
    const { getBasicUserInfo, isAuthenticated, state } = useAuthContext();
    useEffect(() => {
        
            getBasicUserInfo().then((basicUserDetails) => {
                /*console.log(basicUserDetails.username);  GetMobileNumber  GetCurrentQuantityBalance  */
                homeservice.GetMobileNumber(basicUserDetails.mobile).then(results => {
                    setMobileNumberData(results.data);
                })

            })
        homeservice.GetInvoice(MobileNumberData.MSISDN).then(results => {
            setInvoice(results.data);
        })
        homeservice.GetCurrentQuantityBalance(MobileNumberData.MSISDN).then(results => {
            setQuantityBalance(results.data);
        })
        
        }, []);
    return (

        <div action="/action_page">

            <div class="sidenav">
                <img className='avatar' src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7-d5qr9WzS926jiHDPlYrCL01Eb0M8C8c4w&usqp=CAU" alt="Avatar" />
                <h1 style={{ color: "black", marginLeft: "30px", marginTop: "15px" }}>User Name</h1>
            </div>



            <div className="main">

                <div className="container">
                    <table className="styled-table">

                        <tr>
                            <td><h5>Relase Date :</h5></td>
                            <td><p>{Invoice.releaseDate} </p></td>
                        </tr>
                        <tr>
                            <td><h5>Price :</h5></td>
                            <td><p>{Invoice.price} </p></td>
                        </tr>
                        <QuantityBalanceComponant titless={QuantityBalance}/>
                        
                        <tr>
                            <td><h5>Balance :</h5></td>
                            <td><p>450 flex </p></td>
                        </tr>
                        <tr>
                            <td><h5> offer detials :</h5></td>
                            <td><p>detials</p></td>
                        </tr>
                        <tr>
                            <td><h5> Subscripe date :</h5></td>
                            <td><p>2022/2/2</p></td>
                        </tr>
                    </table>

                </div>
            </div>

        </div>


    );
  }


export default Profile;
