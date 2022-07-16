import React, { useState, useEffect } from 'react';
import PlansSecond from './PlansSecond';
import Planquantity from './Planquantity';
import './Plan.css';
import './SignIn.css';
import homeservice from "../services/homeservices";
import { useAuthContext } from "@asgardeo/auth-react";
const PlansFirst = ({ titles }) => {
    const [MobileNumberData, setMobileNumberData] = useState([]);
    const { getBasicUserInfo, isAuthenticated } = useAuthContext();
    //useEffect(() => {
    //    getBasicUserInfo().then((basicUserDetails) => {
    //        /*console.log(basicUserDetails.username);  GetMobileNumber  */
    //        homeservice.GetMobileNumber(basicUserDetails.mobile).then(results => {
    //            setMobileNumberData(results.data);
    //        })
    //    })

    //}, []);

    function onclick(id) {
       // // 1. Make a shallow copy of the items
       // let items = [...MobileNumberData];
       // // 2. Make a shallow copy of the item you want to mutate
       ///* let item = { ...items[0] };*/
       // // 3. Replace the property you're intested in
       // items.PlanId = 'id';
       // // 4. Put it back into our array. N.B. we *are* mutating the array here, but that's why we made a copy first
       ///* items[0] = item;*/
       // // 5. Set the state to our new copy
       // setMobileNumberData(items);
       // homeservice.PutMobileNumber(MobileNumberData.mobileNumberId, MobileNumberData)
    };

    return ( 

        <div>
           
            <div className="big"> {
                titles.map((item, i) => (

                    <div className="ui card collection " key={i}>

                    <div className="content">
                            <div className="header" style={{
                                padding: "5px", fontSize: "1.5em", fontWeight :"bold" 
                            }}>{item.planName}</div>
                            <Planquantity planidone={item.planId} />
                        <div className="meta">
                            <span className="category" style={{
                                padding: "5px"
                                }}> {item.initialPrice}  Pound/month </span>
                            </div>
                     
                    </div>

                    <div className="extra content cont">

                        <dl>
                            <PlansSecond planidtwo={item.planId} />
                        </dl>
                        </div>
                        <button className="subscripe" onClick={() => onclick(item.PlanId)} > إشتراك </button>
                    </div>
                ))
            }
            </div>
            <div class="wrap-collabsible">

                <input id="collapsible" class="toggle" type="checkbox" />
                <label for="collapsible" class="lbl-toggle">More Info</label>
                <div class="collapsible-content">
                    <div class="content-inner">
                        <p> QUnit is by calling one of the object that are embedded in JavaScript,
                        </p>
                    </div>
                </div>
            </div>
        </div>

        
            
        
        )
}
export default PlansFirst