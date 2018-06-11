import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import 'font-awesome/css/font-awesome.css';
import Axios from "axios";

export class Zarzadzaj extends React.Component<RouteComponentProps<{}>, { users: UzytkownikLista[], id: string, email: string, pass: string, name: string, lastName: string, isAdmin: boolean, editMode: boolean }> {
    
    token : string | null;
    
    constructor() {
        super();

        this.state = { users: [] as UzytkownikLista[], id: '', email: '', name: '', pass: '', lastName: '', isAdmin: false, editMode: false };

        this.token = sessionStorage.getItem('token');

        var self = this;

        Axios.get("https://localhost:44319/admin/ListaUzytkownikow",
        { headers: {'Authorization':  'Bearer ' + this.token} })
        .then(function (response)
        {
            var tmpResponse = response.data as UzytkownikLista[];

            self.setState({users: tmpResponse});
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }

    public usunUzytkownika(e : React.MouseEvent<any>, id: string){
        e.preventDefault();

        var bodyFormData = new FormData();
        bodyFormData.set('idUzytkownika', id);

        Axios.post("https://localhost:44319/admin/UsunUzytkownika", bodyFormData,
        {
            headers:
            {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Authorization': 'Bearer ' + this.token
            }
        })
        .catch(function (error)
        {
            console.log(error);
        });
        
        console.log("Użytkownik " + id + " został usunięty");

        window.location.reload();
    }

    public pobierzUzytkownika(e : React.MouseEvent<any>, id: string){
        e.preventDefault();

        var bodyFormData = new FormData();
        bodyFormData.set('idUzytkownika', id);

        var self = this;

        Axios.post("https://localhost:44319/admin/PobierzUzytkownika", bodyFormData,
        { headers: {'Authorization':  'Bearer ' + this.token} })
        .then(function (response)
        {
            var tmpResponse = response.data as Uzytkownik;

            self.setState({
                    id: tmpResponse.idUzytkownik,
                    email: tmpResponse.email,
                    pass: tmpResponse.haslo,
                    name: tmpResponse.imie,
                    lastName: tmpResponse.nazwisko,
                    isAdmin: tmpResponse.admin 
            });
        })
        .catch(function (error)
        {
            console.log(error);
        });

        this.setState({ editMode: true });

        console.log("Jesteś w trybie edycji użytkownika " + id);
    }

    public edytujUzytkownika(e : React.MouseEvent<any>){
        e.preventDefault();
    
        var self = this;
    
        var bodyFormData = new FormData();
        bodyFormData.set('IdUzytkownik', this.state.id);
        bodyFormData.set('Email', this.state.email);
        bodyFormData.set('Haslo', this.state.pass);
        bodyFormData.set('Imie', this.state.name);
        bodyFormData.set('Nazwisko', this.state.lastName);
        bodyFormData.set('Admin', String(this.state.isAdmin));

        var token = sessionStorage.getItem('token');
    
        Axios.post("https://localhost:44319/admin/EdytujUzytkownika", bodyFormData,
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

        this.setState({ editMode: false, id: '', email: '', name: '', pass: '', lastName: '', isAdmin: false });

        console.log("Użytkownik został zaktualizowany");
    }

    public dodajUzytkownika(e : React.MouseEvent<any>){
        e.preventDefault();
    
        var self = this;
    
        var bodyFormData = new FormData();
        bodyFormData.set('Email', this.state.email);
        bodyFormData.set('Haslo', this.state.pass);
        bodyFormData.set('Imie', this.state.name);
        bodyFormData.set('Nazwisko', this.state.lastName);
        bodyFormData.set('Admin', String(this.state.isAdmin));

        var token = sessionStorage.getItem('token');
    
        Axios.post("https://localhost:44319/admin/DodajUzytkownika", bodyFormData,
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

        this.setState({ id: '', email: '', name: '', pass: '', lastName: '', isAdmin: false });

        console.log("Użytkownik został dodany");
    }

    public handleSubmit(e : React.MouseEvent<any>, mode : boolean) {
        e.preventDefault();
    
        if (mode == true)
        {
            this.edytujUzytkownika(e);
        }
        else if (mode == false)
        {
            this.dodajUzytkownika(e);
        }

        window.location.reload();
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

    public handleChangeIsAdmin(e: React.ChangeEvent<any>) {
        e.preventDefault();
    
        this.setState({ isAdmin: e.target.value });
    }
    
    public render() {
        return <div>
            <h1>Zarządzaj użytkownikami</h1>
            <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Imię</th>
                        <th>Nazwisko</th>
                        <th>Email</th>
                        <th>Admin</th>
                        <th>Zarządzaj</th>
                    </tr>
                </thead>

                <tbody>
                {this.state.users.map((uzytkownik,index) =>
                    <tr key={uzytkownik.idUzytkownik}>
                        <td>{uzytkownik.idUzytkownik}</td>
                        <td>{uzytkownik.imie}</td>
                        <td>{uzytkownik.nazwisko}</td>
                        <td>{uzytkownik.email}</td>
                        <td>{uzytkownik.admin}</td>
                        <td>
                            <span className='fa fa-minus' onClick={(e) => this.usunUzytkownika(e, uzytkownik.idUzytkownik)}></span> <span className='fa fa-id-card' onClick={(e) => this.pobierzUzytkownika(e, uzytkownik.idUzytkownik)}></span>
                        </td>
                    </tr>
                )}
                </tbody>
            </table>

            <br />

            <h1>Dodaj/edytuj użytkownika</h1>
            <Form>
                <FormGroup>
                    <Label for="email">Email</Label>
                    <Input type="email" onChange={(e) => this.handleChangeEmail(e)} value={this.state.email}/>
                    <FormText>Wprowadź email, który będzie służył jako nazwa użytkownika</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input type="password" onChange={(e) => this.handleChangePass(e)} value={this.state.pass}/>
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="imie">Imię</Label>
                    <Input type="text" onChange={(e) => this.handleChangeName(e)} value={this.state.name}/>
                    <FormText>Podaj imię</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="nazwisko">Nazwisko</Label>
                    <Input type="text" onChange={(e) => this.handleChangeLastName(e)} value={this.state.lastName}/>
                    <FormText>Podaj nazwisko</FormText>
                </FormGroup>
                <FormGroup check>
                    <Label check>Admin</Label>
                    <Input type="checkbox" onChange={(e) => this.handleChangeIsAdmin(e)} checked={this.state.isAdmin}/>
                    <FormText>Zmień rolę użytkownika w systemie</FormText>
                </FormGroup>
                <Button type="button" onClick={(e) => this.handleSubmit(e, this.state.editMode)}>Wyślij</Button>
            </Form>

        </div>;
    }
}

interface Uzytkownik {
    idUzytkownik: string;
    email: string;
    haslo: string;
    imie: string;
    nazwisko: string;
    admin: boolean;
}

interface UzytkownikLista {
    idUzytkownik: string;
    email: string;
    imie: string;
    nazwisko: string;
    admin: string;
}