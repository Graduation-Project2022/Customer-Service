import React from 'react';

//import homeservice from "../services/homeservices";
//import { useAuthContext } from "@asgardeo/auth-react";
const QuantityBalanceComponant = ({ titless }) => {

    return (<>{
        titless.map((item, i) => { 
            if(item.quantityTypeID === 1) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} Units </p></td>
                </tr>;
            }
            if (item.quantityTypeId === 4) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} Minutes </p></td>
                </tr>;
            }
            if (item.quantityTypeId === 6) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} MegaBytes </p></td>
                </tr>;
            }
            if (item.quantityTypeId === 2) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} EGP </p></td>
                </tr>;
            }
            if (item.quantityTypeId === 7) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} SMS </p></td>
                </tr>;
            }
            if (item.quantityTypeId === 8) {
                return <tr>
                    <td><h5>currentBalance :</h5></td>
                    <td><p>{item.currentBalance} International Minutes  </p></td>
                </tr>;
            }
            
        
        })}
        



        </>
        )
}
export default QuantityBalanceComponant