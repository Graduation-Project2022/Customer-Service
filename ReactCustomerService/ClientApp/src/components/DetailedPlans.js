import React, { useState, useEffect } from 'react';
import homeservice from "../services/homeservices";
//import { useAuthContext } from "@asgardeo/auth-react";
import { useLocation } from 'react-router-dom';
import PlansFirst from './PlansFirst';

const DetailedPlans = () => {
    const location = useLocation();
    const { planslink } = location.state;
    const [Plans, setPlans] = useState([]);


     //function onSubscribe (id) {
     //   // 1. Make a shallow copy of the items
     //   let items = [...this.state.MobileNumberData];
     //   // 2. Make a shallow copy of the item you want to mutate
     //   let item = { ...items[0] };
     //   // 3. Replace the property you're intested in
     //   item.PlanId = 'i';
     //   // 4. Put it back into our array. N.B. we *are* mutating the array here, but that's why we made a copy first
     //   items[0] = item;
     //   // 5. Set the state to our new copy
     //   this.setState({ MobileNumberData: items });
     //   homeservice.PutMobileNumber(this.state.MobileNumberData.mobileNumberId, this.state.MobileNumberData)
     //   };
    useEffect(async () => {
        homeservice.GetPlan(planslink).then(res => {
            setPlans(res.data);
            console.log(res.data);
        });



    }, [planslink]);

    return ( 
        <div>
            <PlansFirst titles={Plans} />

        </div>
            
        )
    
}
export default DetailedPlans




