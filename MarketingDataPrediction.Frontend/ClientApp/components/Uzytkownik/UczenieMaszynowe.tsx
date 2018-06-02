import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import Axios from 'axios';
var reactCSV = require('react-csv') as any;

interface State {
    rezultat: UczenieBO;
    naglowki: string[];
    ladowanie: boolean;
}

export class UczenieMaszynowe extends React.Component<RouteComponentProps<{}>, State> {
    constructor() {
        super();

        this.state = { rezultat: {dane: [], wyniki: [], blad: 0} as UczenieBO, naglowki: ["Wiek", "Wyksztalcenie", "Kredyt", "Hipoteka", "Stanowisko",
        "StatusMatrymonialny", "KredytKonsumencki", "Cci", "Cev", "Cpi",
        "Euribor3m", "IloscPracownikow", "DlugoscKontaktu", "DzienKontaktu", "MiesiacKontaktu",
        "RodzajKontaktu", "IloscDni", "IloscProb", "IloscProbAkt", "PoprzedniRezultat", "Wynik"], ladowanie: false };

        var token = sessionStorage.getItem('token');

        var self = this;

        debugger;

        Axios.get("https://localhost:44319/uzytkownik/UczenieMaszynowe",
        { headers: {'Authorization':  'Bearer ' + token} })
        .then(function (response)
        {
            debugger;
            var tmpResponse = response.data as UczenieBO;

            self.setState({rezultat: tmpResponse});
        })
        .catch(function (error)
        {
            console.log(error);
        });
    }

    public render() {
        let contents = this.state.ladowanie
            ? <p><em>Ładowanie...</em></p>
            : UczenieMaszynowe.renderTable(this.state.rezultat);

        return <div>
            <reactCSV.CSVLink data={this.state.rezultat.dane} headers={this.state.naglowki}>Eksportuj wyniki</reactCSV.CSVLink>
            <h1>Wyniki uczenia</h1>
            {contents}
        </div>;
    }

    private static renderTable(rezultat: UczenieBO) {
        var dane = rezultat.dane;
        var wyniki = rezultat.wyniki;

        return <table className='table'>
            <thead>
                <tr>
                    <th>Wiek</th>
                    <th>Wykształcenie</th>
                    <th>Kredyt</th>
                    <th>Hipoteka</th>
                    <th>Stanowisko</th>
                    <th>Status matrymonialny</th>
                    <th>Kredyt konsumencki</th>
                    <th>CCI</th>
                    <th>CEV</th>
                    <th>CPI</th>
                    <th>EURIBOR3M</th>
                    <th>Ilość pracowników</th>
                    <th>Długość kontaktu</th>
                    <th>Dzień kontaktu</th>
                    <th>Miesiąc kontaktu</th>
                    <th>Rodzaj kontaktu</th>
                    <th>Ilość dni</th>
                    <th>Ilość prób</th>
                    <th>Ilość prób (teraz)</th>
                    <th>Poprzedni rezultat</th>
                    <th>Wynik</th>
                </tr>
            </thead>
            <tbody>
                {rezultat.dane.map(klient =>
                    <tr>
                        <td>{klient[0]}</td>
                        <td>{klient[1]}</td>
                        <td>{klient[2]}</td>
                        <td>{klient[3]}</td>
                        <td>{klient[4]}</td>
                        <td>{klient[5]}</td>
                        <td>{klient[6]}</td>
                        <td>{klient[7]}</td>
                        <td>{klient[8]}</td>
                        <td>{klient[9]}</td>
                        <td>{klient[10]}</td>
                        <td>{klient[11]}</td>
                        <td>{klient[12]}</td>
                        <td>{klient[13]}</td>
                        <td>{klient[14]}</td>
                        <td>{klient[15]}</td>
                        <td>{klient[16]}</td>
                        <td>{klient[17]}</td>
                        <td>{klient[18]}</td>
                        <td>{klient[19]}</td>
                        <td>{klient[20]}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface UczenieBO {
    dane: string[][];
    wyniki: number[];
    blad: number;
}
