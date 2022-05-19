import React, { Component } from 'react';

export class FetchData extends Component {

  constructor(props) {
    super(props);
    this.state = { reports: [], loading: true };
  }

  componentDidMount() {
      this.populateReportData();
  }
 
  static renderReportsTable(reports) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Artifact Type</th>
            <th>Artifact Name</th>
            <th>OS</th>
            <th>Threats</th>
          </tr>
        </thead>
        <tbody>
          {reports.map(report =>
            <tr key={report.id}>
                <td>{report.artifactType}</td>
                <td>{report.artifactName}</td>
                <td>{report.metaData.os.family} {report.metaData.os.name}</td>
                <td>{report.results[0].vulnerabilities.length}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : FetchData.renderReportsTable(this.state.reports);

    return (
      <div>
        <h1 id="tabelLabel" >Trivy Reports</h1>
        <p>This component Fetches all reports.</p>
        {contents}
      </div>
    );
  }

  async populateReportData() {
    const response = await fetch('/api/report');
    const data = await response.json();
    console.log(data)
    this.setState({ reports: data, loading: false });
  }
}
