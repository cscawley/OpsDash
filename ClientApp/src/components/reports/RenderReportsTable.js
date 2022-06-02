import React, { Component } from 'react';
import { RenderReport } from './RenderReport';
export class RenderReportsTable extends Component {
    constructor(props) {
        super(props);
        this.state = { inReport: false, reportFull: {} };
    }

    handleClick(report) {
        this.setState({
            inReport: true,
            reportFull: report
        });
        console.log(report);
    }

    render() {
        let contents = this.state.inReport
            ? <RenderReport report={this.state.reportFull} />
            : <table className='table' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Artifact Type</th>
                        <th>Artifact Name</th>
                        <th>OS</th>
                        <th>Threats</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.reports.map(report =>
                        <tr className={report.results[0].highest} key={report.id} onClick={() => this.handleClick(report) }>
                            <td>{report.artifactType}</td>
                            <td>{report.artifactName}</td>
                            <td>{report.metaData.os.family} {report.metaData.os.name}</td>
                            <td>{report.results[0].vulnerabilities.length}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        return (
        <div>
            {contents}
        </div>
    )
  }
}
