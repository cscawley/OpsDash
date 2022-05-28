import React, { Component } from 'react';

export class FetchAlerts extends Component {

  constructor(props) {
    super(props);
    this.state = { reports: [], loading: true};
  }

  //componentDidMount() {
  //   this.populateReportData();
  //}
 
  static renderReportsTable(reports) {
    return (
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
          {reports.map(report =>
            <tr className={report.results[0].highest} key={report.id}>
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
        : FetchAlerts.renderReportsTable(this.state.reports, this.state.severity);

    return (
      <div>
        <h1 id="tabelLabel" >Latest Reports</h1>
        {contents}
      </div>
    );
  }
  mostSevere(data) {
    let sevArray = ["UNKNOWN", "LOW", "MEDIUM", "HIGH", "CRITICAL"]
    data.forEach(report => {
      let highest = null
      report.results[0].vulnerabilities.forEach(vuln => {
        if (sevArray.indexOf(vuln.severity) > highest){
          highest = sevArray.indexOf(vuln.severity)
        }
      })
      report.results[0].highest = sevArray[highest]
    })
    return data
  }
  //async populateReportData() {
    // const response = await fetch('/api/latest');
    // const data = await response.json();
    // console.log(this.mostSevere(data))
    // this.setState({ reports: this.mostSevere(data), loading: false });
  //}
}