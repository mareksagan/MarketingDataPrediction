import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { StronaGlowna } from './components/StronaGlowna';

import { Zarejestruj } from './components/Uzytkownik/Zarejestruj';
import { Zaloguj } from './components/Shared/Zaloguj';
import { Profil } from './components/Shared/Profil';
import { UczenieMaszynowe } from './components/Uzytkownik/UczenieMaszynowe';
import { Statystyki } from './components/Uzytkownik/Statystyki';
import { StatystykiSystemu } from './components/Admin/StatystykiSystemu';

export const routes = <Layout>
    <Route exact path='/' component={StronaGlowna} />

    <Route path='/zarejestruj' component={Zarejestruj} />
    <Route path='/zaloguj' component={Zaloguj} />
    {/*<Route path='/dashboard' component={Dashboard} />*/}
    <Route path='/statystyki' component={Statystyki} />
    <Route path='/profil' component={Profil} />
    <Route path='/uczenieMaszynowe' component={UczenieMaszynowe} />
    <Route path='/statystykiSystemu' component={Statystyki} />
</Layout>;
