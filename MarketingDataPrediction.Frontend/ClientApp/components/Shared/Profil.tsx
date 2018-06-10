import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import Axios from "axios";

export class Profil extends React.Component<RouteComponentProps<{}>, { email: string, pass: string, name: string, lastName: string }> {
    constructor() {
        super();
    
        this.state = { email: '', pass: '', name: '', lastName: '' };
    
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChangeEmail = this.handleChangeEmail.bind(this);
        this.handleChangePass = this.handleChangePass.bind(this);
        this.handleChangeName = this.handleChangeName.bind(this);
        this.handleChangeLastName = this.handleChangeLastName.bind(this);

        this.handleGet();
    }

    public handleGet() {
        
        var self = this;

        var token = sessionStorage.getItem('token');

        Axios.get("https://localhost:44319/uzytkownik/ZmienProfil",
        { headers: {'Authorization': 'Bearer ' + token}})
        .then(function (response)
        {
            var tmpUserResponse = response.data as UserBO;

            self.setState({
                email: tmpUserResponse.email,
                pass: tmpUserResponse.haslo,
                name: tmpUserResponse.imie,
                lastName: tmpUserResponse.nazwisko
            });
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }

    public handleSubmit(e : React.MouseEvent<any>) {
        e.preventDefault();
    
        var self = this;
    
        var bodyFormData = new FormData();
        bodyFormData.set('Email', this.state.email);
        bodyFormData.set('Haslo', this.state.pass);
        bodyFormData.set('Imie', this.state.name);
        bodyFormData.set('Nazwisko', this.state.lastName);

        var token = sessionStorage.getItem('token');
    
        Axios.post("https://localhost:44319/uzytkownik/ZmienProfil", bodyFormData,
        {
            headers:
            {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Authorization': 'Bearer ' + token
            }
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

    public handleChangeName(e: React.ChangeEvent<any>) {
        e.preventDefault();
    
        this.setState({ name: e.target.value });
    }

    public handleChangeLastName(e: React.ChangeEvent<any>) {
        e.preventDefault();
    
        this.setState({ lastName: e.target.value });
    }

    public render() {
        return <div>
            <h1>Edytuj profil</h1>
            <Form>
                <FormGroup>
                    <Label for="email">Email</Label>
                    <Input type="email" onChange={(e) => this.handleChangeEmail(e)} placeholder="Email" value={this.state.email}/>
                    <FormText>Wprowadź email</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input type="password" onChange={(e) => this.handleChangePass(e)} placeholder='Hasło' value={this.state.pass}/>
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="imie">Imię</Label>
                    <Input type="text" onChange={(e) => this.handleChangeName(e)} placeholder="Imię" value={this.state.name}/>
                    <FormText>Podaj swoje imię</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="nazwisko">Nazwisko</Label>
                    <Input type="text" onChange={(e) => this.handleChangeLastName(e)} placeholder="Nazwisko" value={this.state.lastName}/>
                    <FormText>Podaj swoje nazwisko</FormText>
                </FormGroup>
                <Button type="button" onClick={(e) => this.handleSubmit(e)}>Edytuj profil</Button>
            </Form>

        </div>;
    }
}

interface UserBO {
    email: string,
    haslo: string;
    imie: string;
    nazwisko: string;
}
