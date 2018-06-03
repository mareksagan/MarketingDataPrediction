import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { StronaGlowna } from './components/StronaGlowna';

import { Zarejestruj } from './components/Uzytkownik/Zarejestruj';
import { Zaloguj } from './components/Shared/Zaloguj';
import { Wyloguj } from './components/Shared/Wyloguj';
import { Profil } from './components/Shared/Profil';
import { UczenieMaszynowe } from './components/Uzytkownik/UczenieMaszynowe';
import { Statystyki } from './components/Uzytkownik/Statystyki';
import { StatystykiSystemu } from './components/Admin/StatystykiSystemu';
import { Zarzadzaj } from './components/Admin/Zarzadzaj';


export const routes = <Layout>
    <Route exact path='/' component={StronaGlowna} />

    <Route path='/zarejestruj' component={Zarejestruj} />
    <Route path='/zaloguj' component={Zaloguj} />
    <Route path='/wyloguj' component={Wyloguj} />
    <Route path='/statystyki' component={Statystyki} />
    <Route path='/profil' component={Profil}/>
    <Route path='/uczenieMaszynowe' component={UczenieMaszynowe} />
    <Route path='/zarzadzaj' component={Zarzadzaj} />
    <Route path='/statystykiSystemu' component={StatystykiSystemu} />
</Layout>;
