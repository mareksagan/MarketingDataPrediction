import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import 'font-awesome/css/font-awesome.css';

export class Zarzadzaj extends React.Component<RouteComponentProps<{}>, {}> {
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
                    {/*<FormFeedback>Email jest dostępny</FormFeedback>*/}
                    <FormText>Wprowadź email, który będzie służył jako nazwa użytkownika</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input />
                    {/*<FormFeedback valid>Sweet! that name is available</FormFeedback>*/}
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="imie">Imię</Label>
                    <Input /> {/* <Input valid/> <Input invalid /> */}
                    {/*<FormFeedback valid>Sweet! that name is available</FormFeedback>*/}
                    <FormText>Podaj swoje imię</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="nazwisko">Nazwisko</Label>
                    <Input />
                    {/*<FormFeedback>Oh noes! that name is already taken</FormFeedback>*/}
                    <FormText>Podaj swoje nazwisko</FormText>
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

{/*Pass a whole Uzytkownik table with their non-sensitive data and display it in a table
 Finish forms with axios*/}