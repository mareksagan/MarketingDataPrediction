import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';
import { Link } from "react-router-dom";

export class Zaloguj extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>

            <Form>
                <FormGroup>
                    <Label for="email">Email</Label>
                    <Input />
                    {/*<FormFeedback>Email jest dostępny</FormFeedback>*/}
                    <FormText>Wprowadź email</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="haslo">Hasło</Label>
                    <Input />
                    {/*wyloguj przez nadpisanie null token*/}
                    <FormText>Wprowadź hasło do konta</FormText>
                </FormGroup>
                <Button>Zaloguj</Button>
            </Form>
            <br/>
            <span>

            
            Nie masz konta?
            
            <br/>
            <Link to={'/zarejestruj'}>
                <span className='glyphicon glyphicon-plus-sign'></span> Zarejestruj
            </Link>

            </span>
        </div>;
    }
}
