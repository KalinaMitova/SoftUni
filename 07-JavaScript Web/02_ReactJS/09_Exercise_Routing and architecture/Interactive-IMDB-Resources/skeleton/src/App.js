import React, { Component, Fragment } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './Header/Header';
import Home from './Home/Home';
import Login from './Login/Login';
import Register from './Register/Register';
import Create from './Create/Create';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      user: {
        isLoggedIn: false,
        username: '',
        userId: '',
        token: '',
        isAdmin: false,
      },
    };

    this.login = this.login.bind(this);
    this.logout = this.logout.bind(this);
  }

  login(user) {    
    fetch('http://localhost:9999/auth/signin', {
      method: 'POST',
      body: JSON.stringify(user),
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((response) => response.json())
      .then((data) => {
        
        if(!data.token || !data.username || !data.userId) {
          // TODO: Toastify errors;
          console.log(data.message);
          return;
        }
        
        localStorage.setItem('username', data.username);
        localStorage.setItem('userId', data.userId);
        localStorage.setItem('token', data.token);
        localStorage.setItem('isAdmin', data.isAdmin);

        this.setState({
          user: {
            isLoggedIn: true,
            username: data.username,
            userId: data.userId,
            token: data.token,
            isAdmin: data.isAdmin,
          },
        });      
        // TODO: Toastify data.message "User created!";
        console.log(data.message);
      })
      .catch(console.log);
  }

  logout(event) {
    event.preventDefault();

    localStorage.removeItem('username');
    localStorage.removeItem('userId');
    localStorage.removeItem('token');
    localStorage.removeItem('isAdmin');

    this.setState({
      user: {
        isLoggedIn: false,
        username: '',
        userId: '',
        token: '',
        isAdmin: false,
      },
    });
  }

  componentDidMount() {
    const username = localStorage.getItem('username');
    const userId = localStorage.getItem('userId');
    const token = localStorage.getItem('token');
    const isAdmin = localStorage.getItem('isAdmin');

    if(localStorage.getItem('token')) {
      this.setState({
        user: {
          isLoggedIn: true,
          username: username,
          userId: userId,
          token: token,
          isAdmin: isAdmin,
        },
      });      
    }
  }

  render() {
    return (
      <div className="App">
          <Router>
            <Fragment>
              <Header logout={this.logout} user={this.state.user} />
              <Switch>
                <Route exact path="/" render={() => <Home user={this.state.user}/>} />
                <Route exact path="/login" render={() => <Login login={this.login} user={this.state.user}/>} />
                <Route exact path="/register" render={() => <Register login={this.login} user={this.state.user}/>} />
                <Route exact path="/movie/create" render={() => <Create user={this.state.user}/>} />
              </Switch>
            </Fragment>
          </Router>
      </div>
    );
  }
}

export default App;
