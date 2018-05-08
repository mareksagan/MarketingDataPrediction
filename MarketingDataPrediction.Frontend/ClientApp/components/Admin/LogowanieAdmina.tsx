import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Form, FormGroup, Label, Input, FormFeedback, FormText } from 'reactstrap';

export class LogowanieAdmina extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>

            <Form>
                <FormGroup>
                    <Label for="exampleEmail">Input without validation</Label>
                    <Input />
                    <FormFeedback>You will not be able to see this</FormFeedback>
                    <FormText>Example help text that remains unchanged.</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="exampleEmail">Valid input</Label>
                    <Input valid />
                    <FormFeedback valid>Sweet! that name is available</FormFeedback>
                    <FormText>Example help text that remains unchanged.</FormText>
                </FormGroup>
                <FormGroup>
                    <Label for="examplePassword">Invalid input</Label>
                    <Input invalid />
                    <FormFeedback>Oh noes! that name is already taken</FormFeedback>
                    <FormText>Example help text that remains unchanged.</FormText>
                </FormGroup>
                </Form>
                </div>;
    }
}
//usunąć inne paczki npm, niż reactstrap
//porobić widoki
//napisać kontrolery
//przywrócić reactstrap do wersji 5.0.0
//enums