import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import { Link } from "react-router-dom";
import Axios from 'axios';
import 'font-awesome/css/font-awesome.css';

export class Zaloguj extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    public handleSubmit(e : React.MouseEvent<any>) {
        e.preventDefault();

        var self = this;

        var bodyFormData = new FormData();
        bodyFormData.set('Email', 'b@domena.pl');
        bodyFormData.set('Haslo', 'haslo123');

        Axios.post("https://localhost:44319/token", bodyFormData,
        { headers: {'Content-Type': 'application/x-www-form-urlencoded' }})
        .then(function (response)
        {
            var tmpTokenResponse = response.data as TokenResponse;
            sessionStorage.setItem('token', tmpTokenResponse.accessToken);
            debugger;
            console.log("Authenticated: " + String(tmpTokenResponse.authenticated));
            window.location.reload();
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }

    public render() {
        return <div>
            {/* <Form>
                <Label for='Zaloguj'>Zaloguj</Label>
                <FormGroup>
                    
                    <Input placeholder="Email"/>
                    <FormFeedback>Email jest dostępny</FormFeedback>
                    <FormText>Wprowadź email</FormText>
                </FormGroup>
                <FormGroup>
                    <Input placeholder='Hasło'/>
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <Button onClick={(e) => this.handleSubmit(e)}>Zaloguj</Button>
            </Form>*/}

            <Button onClick={(e) => this.handleSubmit(e)}>Zaloguj</Button>

            <br/>

            <span>
            Nie masz konta?
            <br/>
            <Link to={'/zarejestruj'}>
                <span className='fa fa-plus'></span> Zarejestruj
            </Link>

            </span>
        </div>;
    }
}

interface TokenResponse {
    authenticated: boolean,
    created: string;
    expiration: string;
    accessToken: string;
    message: string;
}
