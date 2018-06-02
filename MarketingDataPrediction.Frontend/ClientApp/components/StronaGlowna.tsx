import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';

export class StronaGlowna extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>Witaj!</h1>
            Witaj na stronie głównej systemu uczenia maszynowego.
            System uczenia maszynowego zostanie napisany w Visual Studio 2017
            z wykorzystaniem  technologii ASP.NET Core 2.0 WebAPI, Microsoft SQL Server 2016, Entity Framework Core, Accord.NET, ReactJS/NodeJS, xUnit.NET i NSubstitute. [10,13] [19]
            W rozwiązaniu zdecydowano się na zastosowanie architektury czystej. Ułatwi to wykrywanie błędów w projekcie przy zachowaniu jego przejrzystej/prostej struktury. Przy projektowaniu systemu użyto podejścia Code First, czyli najpierw stworzono odpowiednią bazę danych jako podstawę projektu, a następnie wygenerowano z niej odpowiedni model przy użyciu odpowiedniego narzędzia ORM.
            Baza powstała z samodzielnie przetłumaczonej bazy danych w formacie CSV. Ze względu na swój względnie duży rozmiar (~5 MB) została ona podzielona na 5 osobnych tabel w celu poprawienia wydajności.
            Oprogramowanie będzie działało w oparciu o relacyjną bazę danych. Jako system zarządzania bazą danych został wybrany Microsoft SQL Server 2016, głównie ze względu na łatwość połączenia takiej bazy danych do oprogramowania tworzonego za pomocą narzędzia Microsoft Visual Studio, w którym implementowany będzie cały projekt.
        </div>;
        
    }
}
