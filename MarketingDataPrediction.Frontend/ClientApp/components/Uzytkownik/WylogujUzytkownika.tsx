import * as React from "react";
import * as ReactDOM from "react-dom";
import { RouteComponentProps } from 'react-router';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export class WylogujUzytkownika extends React.Component<RouteComponentProps<{}>, {}> {

    public render() {
        return <div>
            {/*<Modal isOpen>
                    <ModalHeader >Wylogowanie</ModalHeader>
                    <ModalBody> */}
            Zostałeś wylogowany!
                    {/*</ModalBody>
                    <ModalFooter>
                        Footer
                    </ModalFooter>
                </Modal>*/}
        </div>
    }
}