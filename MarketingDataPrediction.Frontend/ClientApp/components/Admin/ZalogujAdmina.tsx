import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';

export class ZalogujAdmina extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>

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
                <Button>Zaloguj</Button>
            </Form>

        </div>;
    }
}
