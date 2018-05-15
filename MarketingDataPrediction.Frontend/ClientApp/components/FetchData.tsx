import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataExampleState {
    klienci: KlientWynik[];
    loading: boolean;
}

export class FetchData extends React.Component<RouteComponentProps<{}>, FetchDataExampleState> {
    constructor() {
        super();
        this.state = { klienci: [], loading: true };

        fetch('http://localhost:52025/Uzytkownik/Get')
            .then(response => response.json() as Promise<KlientWynik[]>)
            .then(data => {
                this.setState({ klienci: data, loading: false });
            });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.klienci);

        return <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            { contents }
        </div>;
    }

    private static renderForecastsTable(klienci: KlientWynik[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Wiek</th>
                    <th>Wykształcenie</th>
                    <th>Hipoteka</th>
                    <th>Kredyt</th>
                    <th>Wynik</th>
                </tr>
            </thead>
            <tbody>
                {klienci.map(klient =>
                    <tr key={klient.id} >
                        <td>{klient.wiek}</td>
                        <td>{klient.wyksztalcenie}</td>
                        <td>{klient.hipoteka}</td>
                        <td>{klient.kredyt}</td>
                        <td>{klient.wynik}</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

interface KlientWynik {
    id: string,
    wiek: number;
    wyksztalcenie: string;
    hipoteka: string;
    kredyt: string;
    wynik: string;
}
