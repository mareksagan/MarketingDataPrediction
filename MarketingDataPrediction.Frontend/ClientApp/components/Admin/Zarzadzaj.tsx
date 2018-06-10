import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import 'font-awesome/css/font-awesome.css';
import Axios from "axios";

export class Zarzadzaj extends React.Component<RouteComponentProps<{}>, { users: Uzytkownik[], ladowanie: boolean }> {
    constructor() {
        super();

        this.state = { users: [] as Uzytkownik[], ladowanie: false };

        var token = sessionStorage.getItem('token');

        var self = this;

        // Axios.get("https://localhost:44319/admin/EdytujUzytkownika",
        // { headers: {'Authorization':  'Bearer ' + token} })
        // .then(function (response)
        // {
        //     var tmpResponse = response.data as UczenieBO;

        //     console.log('Przybliżony błąd: ' + tmpResponse.blad);

        //     self.setState({rezultat: tmpResponse});
        // })
        // .catch(function (error)
        // {
        //     console.log(error);
        // });
    }

    public usunUzytkownika(){

    }

    public edytujUzytkownika(){

    }
    
    public render() {
        return <div>
            <h1>Zarządzaj użytkownikami</h1>
            <table className='table'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Email</th>
                        <th>Imię</th>
                        <th>Nazwisko</th>
                        <th>Zarządzaj</th>
                    </tr>
                </thead>

                <tbody>
                    <tr>
                        <td>4</td>
                        <td>m@mail.pl</td>
                        <td>Marian</td>
                        <td>Jakiś</td>
                        <td><span className='fa fa-minus'></span> <span className='fa fa-id-card'></span></td>
                    </tr>
                </tbody>
            </table>

            <br />

            <h1>Dodaj/edytuj użytkownika</h1>
            <Form>
                <FormGroup>
                    <Label for="email">Email</Label>
                    <Input />
                    <FormText>Wprowadź email, który będzie służył jako nazwa użytkownika</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input />
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="imie">Imię</Label>
                    <Input />
                    <FormText>Podaj imię</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="nazwisko">Nazwisko</Label>
                    <Input />
                    <FormText>Podaj nazwisko</FormText>
                </FormGroup>
                <FormGroup check>
                    <Label check>Jest adminem?
                    <Input type="checkbox" />{' '}</Label>
                    <FormText>Zmień rolę użytkownika w systemie</FormText>
                </FormGroup>
                <Button>Wyślij</Button>
            </Form>

        </div>;
    }
}

interface Uzytkownik {
    id: string;
    email: string;
    haslo: string;
    imie: string;
    nazwisko: string;
    admin: boolean;
}
