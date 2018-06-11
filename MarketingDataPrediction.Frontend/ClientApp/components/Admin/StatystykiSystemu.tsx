import * as React from "react";
import * as ReactDOM from "react-dom";
import { BarChart, Bar, Legend, XAxis, YAxis} from 'recharts';
import { RouteComponentProps } from "react-router";
import Axios from "axios";

export class StatystykiSystemu extends React.Component<RouteComponentProps<{}>, { statystyki: iloscUzytkownikow[] }> {
    constructor() {
        super();

        this.state = { statystyki: [] };

        var token = sessionStorage.getItem('token');

        var self = this;

        Axios.get("https://localhost:44319/admin/StatystykiSystemu",
        { headers: {'Authorization':  'Bearer ' + token} })
        .then(function (response)
        {
            var tmpResponse = response.data;

            console.log(tmpResponse.miesiaceKontaktu);

            self.setState({ statystyki: tmpResponse });
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }
    
    public render() {
        return <div>
            <h1>Użytkownicy i klienci w systemie</h1>
            <BarChart width={700} height={300} data={this.state.statystyki}
            margin={{top: 5, right: 30, left: 20, bottom: 5}}>
            <XAxis dataKey="rodzajUzytkownika"/>
            <YAxis/>
            <Legend />
            <Bar name='Ilość użytkowników' dataKey="iloscUzytkownikow" fill="#8884d8" />
            </BarChart>
        </div>
    }
}

interface iloscUzytkownikow {
    rodzajUzytkownika: string;
    iloscUzytkownikow: number;
}
