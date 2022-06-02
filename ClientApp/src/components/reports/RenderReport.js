import React, { Component } from 'react'

export class RenderReport extends Component {
  render() {
      return (
        <>
        <div>{this.props.report.artifactName}</div>
        <div>{this.props.report.artifactType}</div>
        <div>{this.props.report.date}</div>
        <div>{this.props.report.id}</div>
        <div>{this.props.report.imageID}</div>
        <div>{this.props.report.artifactType}</div>
        <div>{this.props.report.metaData.os.family}</div>
        <div>{this.props.report.metaData.os.name}</div>
        <div>{this.props.report.results[0].class}</div>
        <div>{this.props.report.results[0].highest}</div>
        <div>{this.props.report.results[0].target}</div>
              <div>{this.props.report.results[0].type}</div>
              <table>
                <thead>
                    <tr>
                    </tr>
                </thead>
                <tbody>
                    {this.props.report.results[0].vulnerabilities.map(result =>
                        <tr>
                            <td>{result.vulnerabilityID}</td>
                        </tr>    
                    )}
                </tbody>
              </table>
        </>
    )
  }
}