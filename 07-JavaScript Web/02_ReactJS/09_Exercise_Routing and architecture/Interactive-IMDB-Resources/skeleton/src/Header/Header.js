import React from 'react';
import { NavLink, Link } from 'react-router-dom';

function Header(props) {
    return (
        <header>
            <Link to="/" className="logo">Interactive IMDB</Link>
            <div className="header-right">
                <Link to="/">Home</Link>
                <span>
                    {
                        props.user.isLoggedIn ?
                        <React.Fragment>
                            <Link to="#">Welcome {props.user.username}!</Link>
                            {props.user.isAdmin ? <NavLink to="/create">Create</NavLink> : null}
                            <NavLink to="#" onClick={props.logout}>Logout</NavLink>                                
                        </React.Fragment>
                        :
                        <React.Fragment>
                            <NavLink to="/register">Register</NavLink>
                            <NavLink to="/login">Login</NavLink>
                        </React.Fragment>
                        
                    }
                </span>
            </div>
        </header>
    );
}

export default Header;
