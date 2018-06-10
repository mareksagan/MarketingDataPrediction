import * as React from "react";
import * as ReactDOM from "react-dom";
import { BarChart, Bar, Legend, XAxis, YAxis} from 'recharts';
import { RouteComponentProps, Redirect } from "react-router";
import Axios from "axios";

export class Statystyki extends React.Component<RouteComponentProps<{}>, {statystyki: statystykiResponse}> {
    constructor() {
        super();

        this.state = { statystyki: {} as statystykiResponse};

        var tmpToken = sessionStorage.getItem('token') as string;

        var self = this;

        Axios.get("https://localhost:44319/uzytkownik/Statystyki",
        { headers: {'Authorization':  'Bearer ' + tmpToken} })
        .then(function (response)
        {
            debugger;
            var tmpResponse = response.data as statystykiResponse;

            self.setState({ statystyki: tmpResponse });
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }
    
    public render() {
        return <div>
                <h1>Ilość kontaktów w danym miesiącu</h1>
                <BarChart width={700} height={300} data={this.state.statystyki.miesiaceKontaktu as StatystykiBO[]}
                margin={{top: 5, right: 30, left: 20, bottom: 5}}>
                <XAxis dataKey="miesiac"/>
                <YAxis/>
                <Legend />
                <Bar name='Ilość kontaktów w danym miesiącu' dataKey="iloscKontaktow" fill="#8884d8" />
                </BarChart>
                <h1>Inne statystyki</h1>
                <span>
                    <b>Średni wiek klienta w latach: </b> {this.state.statystyki.sredniWiekKlienta}
                    <br/>
                    <b>Średnia długość kontaktu w minutach: </b> {this.state.statystyki.sredniaDlugoscKontaktu / 60}
                </span>
            </div>      
    }
}

interface StatystykiBO
{
    miesiac: string;
    iloscKontaktow: number;
}

interface statystykiResponse
{
    miesiaceKontaktu: StatystykiBO[];
    sredniWiekKlienta: number;
    sredniaDlugoscKontaktu: number;
    length: number;
}