import * as React from "react";
import * as ReactDOM from "react-dom";
import { BarChart, Bar, Legend, XAxis, YAxis} from 'recharts';
import { RouteComponentProps, Redirect } from "react-router";
import Axios from "axios";

export class Statystyki extends React.Component<RouteComponentProps<{}>, {statystyki: statystykiResponse, token: string}> {
    constructor() {
        super();

        this.state = { statystyki: {} as statystykiResponse, token: "" };

        var tmpToken = sessionStorage.getItem('token') as string;

        this.setState({token: tmpToken });

        var self = this;

        debugger;

        Axios.get("https://localhost:44319/uzytkownik/Statystyki",
        { headers: {'Authorization':  'Bearer ' + tmpToken} })
        .then(function (response)
        {
            debugger;
            var tmpResponse = response.data as statystykiResponse;

            console.log(tmpResponse.miesiaceKontaktu);

            self.setState({ statystyki: tmpResponse });
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }
    
    public render() {
        if (this.state.token == '')
        {
            return <Redirect to='/zaloguj/'/>;
        }
        else
        {
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