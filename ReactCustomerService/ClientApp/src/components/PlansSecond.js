import React, { useState, useEffect } from 'react';

import homeservice from "../services/homeservices";

const PlansSecond = ({ planidtwo }) => {
    const [PlansNd, setPlansNd] = useState([]);
    useEffect(() => {
        homeservice.GetPlansServicesPrice(planidtwo).then(res => {
            setPlansNd(res.data);
            console.log(res.data);
        });

        // billingConditionId , price ,  quantityTypeId  ,  serviceName    
        //   if (item.billingConditionId === 2) {
    }, [planidtwo]);
    return (
        <>  
            {
                PlansNd.map((item, i) => {
                    if (item.billingConditionId === 2) {
                        return <dd className="secondplan" key={i}> {item.serviceName} : {Math.abs(item.price)} unit <br /> </dd>;
                    }
                   
                })
            }


            </>
        )

}
export default PlansSecond