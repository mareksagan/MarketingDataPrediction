import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import { Link } from "react-router-dom";
import Axios from 'axios';
import 'font-awesome/css/font-awesome.css';

export class Zaloguj extends React.Component<RouteComponentProps<{}>, { email: string, pass: string }> {
    constructor() {
        super();

        this.state = { email: '', pass: '' };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChangeEmail = this.handleChangeEmail.bind(this);
        this.handleChangePass = this.handleChangePass.bind(this);
    }

    public handleSubmit(e : React.MouseEvent<any>) {
        e.preventDefault();

        var self = this;

        var bodyFormData = new FormData();
        bodyFormData.set('Email', this.state.email);
        bodyFormData.set('Haslo', this.state.pass);

        Axios.post("https://localhost:44319/token", bodyFormData,
        { headers: {'Content-Type': 'application/x-www-form-urlencoded' }})
        .then(function (response)
        {
            var tmpTokenResponse = response.data as TokenResponse;
            sessionStorage.setItem('token', tmpTokenResponse.accessToken);
            console.log("Authenticated: " + String(tmpTokenResponse.authenticated));
            window.location.reload();
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }

    public handleChangeEmail(e: React.ChangeEvent<any>) {
        e.preventDefault();

        this.setState({ email: e.target.value });
    }

    public handleChangePass(e: React.ChangeEvent<any>) {
        e.preventDefault();

        this.setState({ pass: e.target.value });
    }

    public render() {
        return <div>
            <h1>Logowanie</h1>
            <Form>
                <FormGroup>
                    <Label for="email">Email</Label>
                    <Input type="email" onChange={(e) => this.handleChangeEmail(e)} placeholder="Email" />
                    <FormText>Wprowadź email</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input type="password" onChange={(e) => this.handleChangePass(e)} placeholder='Hasło' />
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <Button type="button" onClick={(e) => this.handleSubmit(e)}>Zaloguj</Button>
            </Form>

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
