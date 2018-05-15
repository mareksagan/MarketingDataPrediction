import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import { ZarejestrujUzytkownika } from './components/Uzytkownik/ZarejestrujUzytkownika';
import { ZalogujUzytkownika } from './components/Uzytkownik/ZalogujUzytkownika';
import { WylogujUzytkownika } from './components/Uzytkownik/WylogujUzytkownika';
import { WyswietlStatystyki } from './components/Uzytkownik/WyswietlStatystyki';
import { EdytujProfilUzytkownika } from './components/Uzytkownik/EdytujProfilUzytkownika';
import { WyswietlWyniki } from './components/Uzytkownik/WyswietlWyniki';

import { ZarejestrujAdmina } from './components/Admin/ZarejestrujAdmina';
import { WylogujAdmina } from './components/Admin/WylogujAdmina';
import { ZalogujAdmina } from './components/Admin/ZalogujAdmina';
import { WyswietlStatystykiSystemu } from './components/Admin/WyswietlStatystykiSystemu';


export const routes = <Layout>
    <Route exact path='/' component={Home} />

    <Route path='/zarejestrujUzytkownika' component={ZarejestrujUzytkownika} />
    <Route path='/zalogujUzytkownika' component={ZalogujUzytkownika} />
    <Route path='/wylogujUzytkownika' component={WylogujUzytkownika} />
    <Route path='/wyswietlStatystyki' component={WyswietlStatystyki} />
    <Route path='/edytujProfilUzytkownika' component={EdytujProfilUzytkownika} />
    <Route path='/wyswietlWyniki' component={WyswietlWyniki} />

    <Route path='/zarejestrujAdmina' component={ZarejestrujAdmina} />
    <Route path='/zalogujAdmina' component={ZalogujAdmina} />
    <Route path='/wylogujAdmina' component={WylogujAdmina} />
    <Route path='/wyswietlStatystykiSystemu' component={WyswietlStatystyki} />
</Layout>;
