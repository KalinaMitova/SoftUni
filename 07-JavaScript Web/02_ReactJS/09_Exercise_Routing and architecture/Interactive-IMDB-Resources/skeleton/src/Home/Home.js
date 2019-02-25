import React, { Component } from 'react';
import './Home.css'

class Home extends Component {
  constructor(props) {
    super(props);

    this.state = {
      movies: [],
    };
  }

  componentDidMount() {
    fetch('http://localhost:9999/feed/movies', {
      'method': 'GET'
    })
      .then((response) => response.json())
      .then((data) => {
        this.setState({
          movies: data.movies,
        })
      })
      .catch(console.log);
  }

  render() {
    return (
      <div className="Home">
        <h1>All movies</h1>
        <ul className="movies">

          {this.state.movies.map((movie) => {
            return (
              <li className="movie" key={movie._id}>
                <h2>{movie.title}</h2>
                <img src={movie.posterUrl} alt="Poster"/>
              </li>
            );
          })}

        </ul>
      </div>
    );
  }
}

export default Home;
