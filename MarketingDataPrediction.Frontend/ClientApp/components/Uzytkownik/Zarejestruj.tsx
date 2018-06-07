import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';

export class Zarejestruj extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Zarejestruj się</h1>
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
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="powtorzHaslo">Powtórz hasło</Label>
                    <Input />
                    <FormText>Powtórz hasło</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="imie">Imię</Label>
                    <Input />
                    <FormText>Podaj swoje imię</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="nazwisko">Nazwisko</Label>
                    <Input />
                    {/*<FormFeedback>Oh noes! that name is already taken</FormFeedback>*/}
                    <FormText>Podaj swoje nazwisko</FormText>
                </FormGroup>
                <Button>Zarejestruj się</Button>
            </Form>

        </div>;
    }
}
