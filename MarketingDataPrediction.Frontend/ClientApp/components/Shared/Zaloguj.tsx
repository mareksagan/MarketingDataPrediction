import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import { Link } from "react-router-dom";

export class Zaloguj extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
        this.state = {
            data: "beniz"
        }
    }

    handleSubmit() {
        this.state = { tokenresponse: [], loading: true };

        fetch('https://localhost:44340/token')
            .then(response => response.json() as Promise<TokenResponse[]>)
            .then(data => {
                this.setState({ tokenResponse: data, loading: false });
            });
    }

    public render() {
        return <div>

            <Form formAction='https://localhost:44319/token' method='POST' onSubmit={this.handleSubmit} >
                <FormGroup>
                    <Label for="Email">Email</Label>
                    <Input />
                    {/*<FormFeedback>Email jest dostępny</FormFeedback>*/}
                    <FormText>Wprowadź email</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="Haslo">Hasło</Label>
                    <Input />
                    {/*wyloguj przez nadpisanie null token*/}
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <Button>Zaloguj</Button>
            </Form>
            <br/>
            <span>
                {/*this.state.data*/}
            Nie masz konta?
            
            <br/>
            <Link to={'/zarejestruj'}>
                <span className='glyphicon glyphicon-plus-sign'></span> Zarejestruj
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