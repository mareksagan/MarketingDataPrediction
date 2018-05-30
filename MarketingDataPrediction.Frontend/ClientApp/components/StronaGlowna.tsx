import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';

export class StronaGlowna extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Witaj!</h1>
            Witaj na stronie głównej systemu uczenia maszynowego
        </div>;
        
    }
}
