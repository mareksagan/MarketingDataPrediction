import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Link, Redirect } from "react-router-dom";
import Axios from 'axios';

export class Wyloguj extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        sessionStorage.setItem('token', '');
    }

    public render() {
        return <Redirect to='/'/>
    }
}
