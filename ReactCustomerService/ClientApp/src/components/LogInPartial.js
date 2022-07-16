import React, { useState } from "react";
import { useAuthContext } from "@asgardeo/auth-react";
import './NavMenu.css';

const LoginPartial = () => {
  
    ///*   const { state, signIn, signOut } = useAuthContext();*/

    //return (
    //    //<span className="App">
    //    //    { state.isAuthenticated
    //    //        ? (<span>hello <h3>{state.username}</h3>
    //    //            <button onClick={() => signOut()}>Logout</button></span>

    //    //            )
    //    //            : <button onClick={() => signIn()}>Login</button>
    //    //    }
    //    //</span>

    //    <h1>hello</h1>
    //)
    const { signIn } = useAuthContext();
    const [signedIn, setSignedIn] = useState(false);

    const handleClick = () => {
        signIn(() => {
            setSignedIn(true);
        });
    }

    return (
        <div>
            {signedIn && <div>You have signed in!</div>}
            <button className='NavBtnLink' onClick={handleClick}> Sign In </button>
        </div>
    );
}
export default LoginPartial