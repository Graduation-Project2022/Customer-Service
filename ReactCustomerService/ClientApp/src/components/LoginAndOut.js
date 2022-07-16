import React from "react";
import { AuthProvider } from "@asgardeo/auth-react";
import LoginPartial from "./LogInPartial";
//useAuthContext

const Login = () => {
    const config = {
        signInRedirectURL: "https://localhost:3000/sign-in",
        signOutRedirectURL: "https://localhost:3000/dashboard",
        clientID: "client ID",
        baseUrl: "https://api.asgardeo.io/t/<org_name>",
        scope: ["openid", "profile"]
    };
 /*   const { state, signIn, signOut } = useAuthContext();*/

    return (
        //<span className="App">
        //    { state.isAuthenticated
        //        ? (<span>hello <h3>{state.username}</h3>
        //            <button onClick={() => signOut()}>Logout</button></span>
                       
        //            )
        //            : <button onClick={() => signIn()}>Login</button>
        //    }
        //</span>
        
        <AuthProvider config={config}>
            <LoginPartial />
        </AuthProvider>
        )
}
export default Login