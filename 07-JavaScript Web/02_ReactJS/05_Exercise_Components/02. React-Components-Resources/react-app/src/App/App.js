import React, { Component } from 'react';
import './App.css';
import Street from '../Street/Street';
import House from '../House/House';
import HouseDetails from '../HouseDetails/HouseDetails';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      streets: [],
      selectedStreetId: '',
      selectedHouseId: '',
      hasFetched: false,
    }

    this.streetHoverEvent = this.streetHoverEvent.bind(this);
    this.houseHoverEvent = this.houseHoverEvent.bind(this);
  }

  componentDidMount() {
    fetch('http://localhost:9999/feed/street/all')
      .then(response => response.json())
      .then(data => {
        this.setState({
          streets: data.streets,
          selectedStreetId: data.streets[0]._id,
          selectedHouseId: data.streets[0].homes[0]._id,
          hasFetched: true,
        });
      });
  }

  streetHoverEvent(id) {
    this.setState((state) => ({
      selectedStreetId: id,
      selectedHouseId: state.streets.filter(street => street._id === id)[0].homes[0]._id,
    }));
  }

  houseHoverEvent(id) {
    this.setState({
      selectedHouseId: id,
    });
  }
 
  getSelectedStreetHomes() {
    let streets = this.state.streets.filter(street => {
      return street._id === this.state.selectedStreetId;
    });

    if(streets.length > 0) {
      return streets[0].homes;
    } 

    return [];
  }

  getSelectedHouse() {
    let homes = this.getSelectedStreetHomes();
    
    if(homes.length > 0) {
      let id = this.state.selectedHouseId;
      let filteredHomes = homes.filter(home => {
        return home._id === id;
      });

      if(filteredHomes.length > 0) {
        return filteredHomes[0];
      }
    }

    return null;
  }

  render() {
    let house = this.getSelectedHouse();

    return (
      <div className="App">
        <div className="streets">
          <h2>Streets</h2>
          {
            this.state.streets.map((street) => {
              return (
                <Street location={street.location} streetHoverEvent={this.streetHoverEvent} key={street._id} id={street._id} />
              );
            })
          }
        </div>
        <div className="houses">
            <h2>Houses</h2>
            {
              this.getSelectedStreetHomes().map((house) => {
                return (
                  <House imageUrl={house.imageUrl} houseHoverEvent={this.houseHoverEvent} key={house._id} id={house._id} />
                );
              })
            }
        </div>

        <HouseDetails house={house} />
      </div>
    );
  }
}

export default App;
