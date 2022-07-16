import React, { useState, useEffect } from 'react';

import homeservice from "../services/homeservices";

const Planquantity = ({ planidone }) => {
    const [PlansQN, setPlansQN] = useState([]);
    useEffect(() => {
        homeservice.GetPlansQuantity(planidone).then(res => {
            setPlansQN(res.data);
            console.log(res.data);
        });

        //  quantityTypeId ,  quantity  ,  quantityTypeId

    }, [planidone]);
    return ( 
        <> 
            {
                PlansQN.map((item, i) => {
                    if (item.quantityTypeId === 1) {
                        return <dd className="quatitycolor" key={i }> {item.quantity} Units <br /> </dd>;
                    }
                    if (item.quantityTypeId === 4) {
                        return <dd className="quatitycolor" key={i}> {item.quantity} Minutes <br /> </dd>;
                    }
                    if (item.quantityTypeId === 6) {
                        return <dd className="quatitycolor" key={i}> {item.quantity} MegaBytes <br /> </dd>;
                    }
                    if (item.quantityTypeId === 7) {
                        return <dd className="quatitycolor" key={i}> {item.quantity} SMS <br /> </dd>;
                    }
                    if (item.quantityTypeId === 8) {
                        return <dd className="quatitycolor" key={i}> {item.quantity} International Minutes <br /> </dd>;
                    }

                    
                })
            }


        </>
    )

}
export default Planquantity