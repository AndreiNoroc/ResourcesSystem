import React from 'react';
import {
  Nav,
  NavLink,
  Bars,
  NavMenu,
  NavBtn,
  NavBtnLink,
} from './NavBarElements';

  
const Navbar = () => {
  return (
    <>
      <Nav>
        <Bars />
        <NavMenu>
            <NavLink to='/' activestyle='true'>
                Home
            </NavLink>
            <NavLink to='/getbyname' activestyle='true'>
                GetByName
            </NavLink>
            <NavLink to='/sign-up' activestyle='true'>
                Register
            </NavLink>
            <NavLink to='/addresource' activestyle='true'>
                AddResource
            </NavLink>
            <NavLink to='/updateresource' activestyle='true'>
                UpdateResource
            </NavLink>
            <NavLink to='/admin' activestyle='true'>
                Admin
            </NavLink>
        </NavMenu>
        <NavBtn>
          <NavBtnLink to='/signin'>Sign In</NavBtnLink>
        </NavBtn>
      </Nav>
    </>
  );
};
  
export default Navbar;