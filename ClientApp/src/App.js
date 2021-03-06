import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchArchive } from './components/reports/FetchReports';
import { FetchAlerts } from './components/reports/FetchAlerts';
import { FetchContainers } from './components/reports/FetchContainers';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <AuthorizeRoute path='/containers' component={FetchContainers} />
        <AuthorizeRoute path='/alerts' component={FetchAlerts} />
        <AuthorizeRoute path='/archive' component={FetchArchive} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}
