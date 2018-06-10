import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';

export class StronaGlowna extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Witaj!</h1>
            <p>
                Witaj na stronie głównej systemu uczenia maszynowego!
            </p>
            <p>
                System uczenia maszynowego został napisany w Visual Studio 2017 z wykorzystaniem  technologii ASP.NET Core 2.0 WebAPI,
                Microsoft SQL Server 2016, Entity Framework Core, Accord.NET, ReactJS/NodeJS, xUnit.NET i NSubstitute.
                W rozwiązaniu zdecydowano się na zastosowanie architektury czystej.
            </p>
            <p>
                Ułatwi to wykrywanie błędów w projekcie przy zachowaniu jego przejrzystej/prostej struktury.
            </p>
            <p>
                Przy projektowaniu systemu użyto podejścia Code First, czyli najpierw stworzono odpowiednią bazę danych jako podstawę projektu,
                a następnie wygenerowano z niej odpowiedni model przy użyciu odpowiedniego narzędzia ORM.
            </p>
            <p>
                <div>
                    Baza powstała z samodzielnie przetłumaczonej bazy danych w formacie CSV. Ze względu na swój względnie duży rozmiar (~5 MB)
                    została ona podzielona na osobne tabele w celu poprawienia wydajności.
                </div>
                <br/>
                <div>
                    <a href="http://archive.ics.uci.edu/ml/datasets/Bank+Marketing">Pokaż źródło bazy danych</a>
                </div>
                <br/>
                <div>
                    Została ona zmodyfikowana na potrzeby projektu. Dokonano także jej „czyszczenia” z pustych lub nieprawidłowych rekordów,
                    co jest standardową praktyką przy analizie danych.
                </div>
            </p>
            <p>
                Oprogramowanie będzie działało w oparciu o relacyjną bazę danych. Jako system zarządzania bazą danych został wybrany
                Microsoft SQL Server 2016, głównie ze względu na łatwość połączenia takiej bazy danych do oprogramowania tworzonego
                za pomocą narzędzia Microsoft Visual Studio, w którym implementowany będzie cały projekt.
            </p>
            </div>;
    
    }
}
