import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Trivy Dashboard</h1>
        <p>TrivyDash is a dashboard for consuming and monitoring Trivy scan outputs.</p>
      </div>
    );
  }
}
