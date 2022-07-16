//import React, { Component } from 'react';
//import {
//    Button, Card, CardImg, CardBody, CardTitle, CardText, CardGroup } from 'reactstrap';
//import homeservice from "../services/homeservices";
//import { Link } from 'react-router-dom';
///*import { useAuthContext } from "@asgardeo/auth-react";*/

//export class Home extends Component {
//    constructor(props) {
//        super(props);
//        this.state = {
//            GeneralPlans: []
//           /* MobileNumberData: []*/
//        }
//    }

//    //componentDidMount() {
//    //    const { getBasicUserInfo } = useAuthContext();
//    //    getBasicUserInfo().then((basicUserDetails) => {
//    //        console.log(basicUserDetails.username);
//    //    }
//    //}

//    componentDidMount() {
//        //const { getBasicUserInfo, isAuthenticated } = useAuthContext();
//        //if (isAuthenticated()) {
            //getBasicUserInfo().then((basicUserDetails) => {
            //    /*console.log(basicUserDetails.username);*/
            //    homeservice.GetMobileNumber(basicUserDetails.mobile).then(results => {
            //        this.setState({
            //            MobileNumberData: results.data

            //        });
            //    })
            //})
            //homeservice.GetGeneralPlans(this.state.MobileNumberData.CompanyCode).then(res => {
            //    this.setState({
            //        GeneralPlans: res.data

            //    });
            //})

//        //} else {
            //homeservice.GetGeneralPlans().then(res => {
            //    this.setState({
            //        GeneralPlans: res.data

            //    });
            //})

//        //}



//          }
///*  static displayName = Home.name;*/

//  render () {
//    return (
//        <div>
//            <h1>hello world </h1>
            //<CardGroup>
            //        {
            //        this.state.GeneralPlans.map((item, i) => {
            //            return <Link key={i} tag={Link} className="" to={{ pathname: "/plans", state:  item.generalPlanId }}>
            //                <Card>
            //                <CardImg alt="Card image cap" src="https://picsum.photos/318/180" top width="100%" />
            //                <CardBody>
            //                     <CardTitle tag="h5">
            //                            {item.generalPlanName}
            //                         </CardTitle>
            //                 <CardText>
            //                            Begins at {item.generationTime}
            //                  </CardText>
            //                            <Button>
            //                      Details
            //                  </Button>
            //                 </CardBody>
            //                </Card>
            //                </Link>

            //            })
            //        }

            //</CardGroup>
//      </div>
//    );
//  }
//}


//import {Button} from 'reactstrap';
//import React from 'react';
//import { useAuthContext } from "@asgardeo/auth-react";
//const Home = () => {

//   const { getBasicUserInfo, isAuthenticated } = useAuthContext();
//const basicuser = () => {
   
//    } 
//    return (<div>
//            <h1>hello world </h1>
//            <Button onClick={ basicuser }> click </Button>
//            </div>
//            )

//}
//export default Home


//<Card className='box'>
//    <CardImg alt="Card image cap" src="https://picsum.photos/318/180" top width="100%" />
//    <CardBody className="content">
//        <CardTitle >
//            {item.generalPlanName}
//        </CardTitle>
//        <CardText>
//            Begins at {item.generationTime}
//        </CardText>
//        <Button onClick={onclick}>
//            Details
//        </Button>
//    </CardBody>
//</Card>










import homeservice from "../services/homeservices";
import './Home.css';
import { Link } from 'react-router-dom';
import { useAuthContext } from "@asgardeo/auth-react";
import React, { useState, useEffect } from 'react';

const Home = () => {

    const { getBasicUserInfo, isAuthenticated, state } = useAuthContext();
    const [MobileNumberData, setMobileNumberData] = useState([]);

    const [GeneralPlans, setGeneralPlans] = useState([]);
  
    useEffect(() => {
   
        homeservice.GetGeneralPlans().then(res => {
            setGeneralPlans(res.data);
            console.log(GeneralPlans);
            });
        
        
    }, []);
    const onclick = () => {
        console.log(GeneralPlans);
    }
    
    return (
        <div className='containersecond'>

        
      
                {
                    GeneralPlans.map((item, i) => {
                        return <Link key={i} tag={Link} className="" to={{ pathname: "/plans", state: { planslink: item.generalPlanId } }} >
                            <div className="card">
                                <div className="box">
                                    <div className="content">
                                        <h2> {item.generalPlanName}</h2>
                                        <h3> {item.generalPlanName} </h3>
                                        <p> Begins at {item.generationTime}</p>
                                    </div>
                                </div>
                            </div>
                        </Link>

                    })
                }

          
        </div>

    )
}
export default Home

     // Your code here
        //if (state.isAuthenticated) {
        //    getBasicUserInfo().then((basicUserDetails) => {
        //        /*console.log(basicUserDetails.username);  GetMobileNumber  */
        //        homeservice.GetMobileNumber(basicUserDetails.mobile).then(results => {
        //            setMobileNumberData(results.data);
        //        })
        //    })
        //    homeservice.GetGeneralPlans(MobileNumberData.CompanyCode).then(res => {
        //        setGeneralPlans(res.data);
        //    })

        //} else {
        //    homeservice.GetGeneralPlans().then(res => {
        //        setGeneralPlans(res.data);
        //    });
        //}
