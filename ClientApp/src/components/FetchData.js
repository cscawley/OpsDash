import React, { Component } from 'react';

export class FetchData extends Component {

  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Trivy Archive</h1>
        <p>Coming soon.</p>
        <table className='table' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Artifact Type</th>
            <th>Artifact Name</th>
            <th>OS</th>
            <th>Threats</th>
          </tr>
        </thead>
        <tbody>
        </tbody>
      </table>
      </div>
    );
  }
}
