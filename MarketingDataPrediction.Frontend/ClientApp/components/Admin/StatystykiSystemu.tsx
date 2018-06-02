import * as React from "react";
import * as ReactDOM from "react-dom";
import { BarChart, Bar, Legend, XAxis, YAxis} from 'recharts';
import { RouteComponentProps } from "react-router";
import Axios from "axios";

const data = [
    {
        name: "Klienci",
        value: 41188
    },
    {
        name: "Uzytkownicy",
        value: 1
    },
    {
        name: "Admini",
        value: 1
    }
];

export class StatystykiSystemu extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();

        this.state = { statystyki: {}};

        var token = sessionStorage.getItem('token');

        var self = this;

        debugger;

        Axios.get("https://localhost:44319/uzytkownik/Statystyki",
        { headers: {'Authorization':  'Bearer ' + token} })
        .then(function (response)
        {
            debugger;
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
            <BarChart width={700} height={300} data={data}
            margin={{top: 5, right: 30, left: 20, bottom: 5}}>
            <XAxis dataKey="name"/>
            <YAxis/>
            <Legend />
            <Bar name='Ilość kontaktów w danym miesiącu' dataKey="value" fill="#8884d8" />
            </BarChart>
        </div>
    }
}
