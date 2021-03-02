import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import MinersFetchData from './components/MinersFetchData';
import GoldMineFetchData from './components/GoldMineFetchData';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />        
        <Route path='/fetch-data/' component={MinersFetchData} />
    </Layout>
);
