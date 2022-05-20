import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { FetchAlerts } from './components/FetchAlerts';
import { FetchContainers } from './components/FetchContainers';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/containers' component={FetchContainers} />
        <Route path='/alerts' component={FetchAlerts} />
        <Route path='/archive' component={FetchData} />
      </Layout>
    );
  }
}
