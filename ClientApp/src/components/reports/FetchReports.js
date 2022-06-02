import React, { Component } from 'react';
import { RenderReportsTable } from './RenderReportsTable';
export class FetchArchive extends Component {

    constructor(props) {
        super(props);
        this.state = { reports: [], loading: true };
    }

    componentDidMount() {
        this.populateReportData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <RenderReportsTable reports={this.state.reports}/>;

        return (
            <div>
                <h1 id="tabelLabel" >Trivy Alerts</h1>
                <p>This component Fetches all alerts.</p>
                {contents}
            </div>
        );
    }
    mostSevere(data) {
        let sevArray = ["UNKNOWN", "LOW", "MEDIUM", "HIGH", "CRITICAL"]
        data.forEach(report => {
            let highest = null
            report.results[0].vulnerabilities.forEach(vuln => {
                if (sevArray.indexOf(vuln.severity) > highest) {
                    highest = sevArray.indexOf(vuln.severity)
                }
            })
            report.results[0].highest = sevArray[highest]
        })
        return data
    }
    async populateReportData() {
        const response = await fetch('/api/report');
        const data = await response.json();
        this.setState({ reports: this.mostSevere(data), loading: false });
    }
}
