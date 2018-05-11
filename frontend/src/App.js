import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Request from 'superagent';
class App extends Component {
  
  constructor(props) {
    super(props)
    this.state = {
      btnap: 1,
      btnre: 0
    }
  }

  HandleAp=()=>{
    this.setState({
      btnap: 1,
      btnre: 0
    });
  }
  
  HandleRe=()=>{
    this.setState({
      btnap: 0,
      btnre: 1
    });
  }
  render() {
    return (
      <div>
        <h1>RENT APP</h1>
        <Apartments/>
        <Regions/>
      </div>
    );
  }
  
}


class Apartments extends Component {
  constructor(props) {
    super(props)
    this.state = {
      apartments: [],      
    }
  }
  
  componentDidMount() {
    let url = "http://localhost:57281/api/apartments"
    Request.get(url).then((response) => {
      let obj = JSON.parse(response.text);
      console.log(obj);
      this.setState ({
        apartments: obj
      })
    })
  }

  render() {
    return (
      <div>
      <h2>APARTMENTS</h2>
      <table className="Table">
        <thead>
          <tr>
            <td>Address</td>
            <td>Price</td>
            <td>Region</td>
          </tr>
        </thead>
        <tbody>
          {this.state.apartments.map(apartment =>
            <tr key={ apartment.id }>
              <td>{ apartment.address }</td>
              <td>{ apartment.price }</td>
              <td>{ apartment.regionID }</td>
            </tr>
          )}
        </tbody>
      </table>
      </div>
    );
  }
}

class Regions extends Component {
  constructor(props) {
    super(props)
    this.state = {
      regions: [],      
    }
  }
  componentDidMount() {
    let url = "http://localhost:57281/api/regions"
    Request.get(url).then((response) => {
      let obj = JSON.parse(response.text);
      console.log(obj);
      this.setState ({
        regions: obj
      })
    })
  }
  render() {
    console.log(this)
    return (
      <div>
      <h2>REGIONS</h2>
      <table className="Table">
        <thead>
          <tr>
            <td>Name</td>
            <td>Tax</td>
          </tr>
        </thead>
        <tbody>
          {this.state.regions.map(region => {
            return (
            <tr key={ region.id }>
              <td>{ region.name }</td>
              <td>{ region.tax }</td>
            </tr>
            )
          }
          )}
        </tbody>
      </table>
      </div>
    );
  }
}


export default App;

