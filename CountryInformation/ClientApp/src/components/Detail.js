import React, { Component } from 'react';
import { Link } from "react-router-dom";

export class Detail extends Component {
    constructor(props) {
        super(props);
        this.state = { Name: '', Capital: '', NumberOfCitizens:''};
    }

    handleNameChange = (event) => {
        this.setState({ Name: event.target.value });
    }
        handleCapitalChange = (event) => {
            this.setState({ Capital: event.target.value });
        }
    handleNumberChange = (event) => {
        this.setState({ NumberOfCitizens: event.target.value });
    }   

            handleSubmit = (event) => {
               

                fetch('country/create', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                        // 'Content-Type': 'application/x-www-form-urlencoded',
                    },
                    // We convert the React state to JSON and send it as the POST body
                    body: JSON.stringify(this.state)
                }).then(function (response) {
                   
                    console.log(response)
                    return response.json();
                });

                event.preventDefault();
            }
        
    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <table>
                    <tr>
                        <td>
                            <label>
                                Name:
                              </label>
                        </td>
                        <td>
                            <input type="text" onChange={this.handleNameChange} />
                        </td>
                     </tr>
                    <tr>
                        <td>
                            <label>
                                Capital:
                             </label>
                        </td>
                        <td>
                            <input type="text" onChange={this.handleCapitalChange} />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Number of citizens:
                            </label>
                        </td>
                        <td>
                            <input type="text" onChange={this.handleNumberChange} />
                        </td>
                
                      <input type="submit" value="Submit" />
                    </tr>
             </table>
            </form>
        );
    }
}
