import React, { Component } from 'react';



export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateCountries();
    };

    

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Capital</th>
            <th>Number of citizens</th>
         
          </tr>
            </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.name}>
                 
              <td>{forecast.name}</td>
                  <td>{forecast.capital}</td>
                  <td>{forecast.numberOfCitizens}</td>            
            </tr>
          )}
            </tbody>
        </table>
      
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >List of Countries</h1>
        <p>This is a full information about Countries </p>
        {contents}
      </div>
    );
  }

  async populateCountries() {
      const response = await fetch('country/get-countries');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
