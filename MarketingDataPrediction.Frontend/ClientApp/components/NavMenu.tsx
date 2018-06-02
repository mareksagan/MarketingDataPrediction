import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
var jwtDecode = require('jwt-decode') as any;

export class NavMenu extends React.Component<{}, {role: string}> {
    constructor() {
        super();

        var token = sessionStorage.getItem('token');

        this.state = {role: ""};

        this.setState({role: (jwtDecode(token) as DecodedToken).role});
    }

    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>Marketing Data Prediction</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <NavLinks role={'Admin'}/>
                </div>
            </div>
        </div>;
    }
}

export class NavLinks extends React.Component<{role: string}, {}> {
    public render() {
        if (this.props.role == 'Uzytkownik')
        {
            return <ul className='nav navbar-nav'>
                <li>
                    <NavLink to={ '/' } exact activeClassName='active'>
                        <span className='glyphicon glyphicon-home'></span> Strona główna
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/uczenieMaszynowe'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Uczenie maszynowe
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/statystyki'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Statystyki
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/profil'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Mój profil
                    </NavLink>
                </li>
            </ul>

        }
        else if (this.props.role == 'Admin')
        {
            return <ul className='nav navbar-nav'>
                <li>
                    <NavLink to={ '/' } exact activeClassName='active'>
                        <span className='glyphicon glyphicon-home'></span> Strona główna
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/zarzadzaj'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Zarządzaj systemem
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/statystykiSystemu'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Statystyki systemu
                    </NavLink>
                </li>
                <li>
                    <NavLink to={'/profil'} activeClassName='active'>
                        <span className='glyphicon glyphicon-log-in'></span> Mój profil
                    </NavLink>
                </li>
            </ul>

        }
        else
        {
            {
                return <ul className='nav navbar-nav'>
                    <li>
                        <NavLink to={ '/' } exact activeClassName='active'>
                            <span className='glyphicon glyphicon-home'></span> Strona główna
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/zaloguj'} activeClassName='active'>
                            <span className='glyphicon glyphicon-log-in'></span> Zaloguj
                        </NavLink>
                    </li>
                </ul>
    
            }
        }
        
    }
}

interface DecodedToken
{
    aud: string;
    exp: number;
    iat: number;
    iss: string;
    jti: string;
    nbf: number;
    role: string;
    unique_name: string;
}
