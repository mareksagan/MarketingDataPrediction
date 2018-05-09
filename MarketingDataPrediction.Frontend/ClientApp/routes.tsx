import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { LogowanieAdmina } from './components/Admin/LogowanieAdmina';
import { RejestracjaUzytkownika } from './components/Uzytkownik/RejestracjaUzytkownika';
import { LogowanieUzytkownika } from './components/Uzytkownik/LogowanieUzytkownika';
import { WylogowanieAdmina } from './components/Admin/WylogowanieAdmina';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata' component={FetchData} />
    <Route path='/rejestracjaUzytkownika' component={RejestracjaUzytkownika} />
    <Route path='/logowanieUzytkownika' component={LogowanieUzytkownika} />
    <Route path='/logowanieAdmina' component={LogowanieAdmina} />
    <Route path='/wylogowanieAdmina' component={WylogowanieAdmina} />
</Layout>;
