//import React, { Component } from 'react';
//import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
//import { Link } from 'react-router-dom';
//import './NavMenu.css';
//import Login from './LoginAndOut';

//export class NavMenu extends Component {
//  static displayName = NavMenu.name;

//  constructor (props) {
//    super(props);

//    this.toggleNavbar = this.toggleNavbar.bind(this);
//    this.state = {
//      collapsed: true
//    };
//  }

//  toggleNavbar () {
//    this.setState({
//      collapsed: !this.state.collapsed
//    });
//  }

//  render () {
//    return (
//      <header>
//        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
//          <Container>
//            <NavbarBrand tag={Link} to="/">ReactCustomerService</NavbarBrand>
//            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
//            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
//              <ul className="navbar-nav flex-grow">
//                <NavItem>
//                  <NavLink tag={Link} className="text-dark" to="/">General Plans</NavLink>
//                </NavItem>

//                 <NavItem>
//                    <NavLink tag={Link} className="text-dark" to="/account">Account</NavLink>
//                  </NavItem>
//              </ul>
//                    </Collapse>
//            <Login/>
//          </Container>
//        </Navbar>                                                  <Link  to='/'>Sign In</Link>
//      </header>
//    );
//  }
//}


import React from 'react';
import { FaBars } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import Login from './LoginAndOut';


const NavMenu = () => {
    return (
        <>
           /* <link href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined" rel="stylesheet" />*/
            
            <nav className='Nav'>
                
                <Link className='NavLink' to='/'>
                  
                        home
                   
                </Link>

                <FaBars className='Bars' />

                <div className='NavMenu'>
                    <Link className='NavLink' to='/account'>
                        Profile
                    </Link>
                    <Link className='NavLink' to='/about'>
                        About Us
                    </Link>
                    <Link className='NavLink' to='/contact'>
                        Contact Us
                    </Link>
                </div>

                <nav className='NavBtn'>
                    <Login />

                </nav>

            </nav>
        </>
    );
};

export default NavMenu;
