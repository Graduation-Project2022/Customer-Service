import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import  About  from './components/About';
import  ContactForm  from './components/Contact';
//import { FetchData } from './components/FetchData';
//import { Counter } from './components/Counter';
import  DetailedPlans  from './components/DetailedPlans';

import './custom.css'
import Profile from './components/Profile';
import { AuthProvider } from "@asgardeo/auth-react";
const App = () => {

    const config = {
        signInRedirectURL: "https://localhost:3000/sign-in",
        signOutRedirectURL: "https://localhost:3000/dashboard",
        clientID: "client ID",
        baseUrl: "https://api.asgardeo.io/t/<org_name>",
        scope: ["openid", "profile"]
    };

    return (
        <AuthProvider config={config} >
          <Layout>
            <Route exact path='/'> <Home/> </Route>
            <Route path='/plans'> <DetailedPlans /> </Route>
            <Route path='/account' component={Profile} />
            <Route path='/about' component={About} />
            <Route path='/contact' component={ContactForm} />
          </Layout>
        </AuthProvider>
    );
  
}
export default App;
