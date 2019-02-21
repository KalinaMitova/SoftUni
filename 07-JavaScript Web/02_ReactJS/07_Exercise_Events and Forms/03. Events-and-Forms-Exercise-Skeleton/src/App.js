import React, {Component} from 'react';
import './App.css';
// import AppHeader from "./App/AppHeader";
import AppContent from "./App/AppContent";
import AppFooter from "./App/AppFooter";
import AppNav from './App/AppNav';

class App extends Component {

    constructor(props) {
        super(props);
        this.state = {
            user: {
                'userId': '',
                'username': '',
                'isLoggedIn': false
            },
            games: [],
            hasFetched: false,
            loginForm: false,
        }
    }

    registerUser(user) {
        // TODO: register a user and login
        if(this.state.user.isLoggedIn) {
            console.log('You are already logged in. Please logout first!');
            return;
        }

        fetch('http://localhost:9999/auth/signup', {
            method: 'POST',
            body: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => response.json())
            .then((data) => {                
                if(data.errors) {
                    console.log(data.errors.map(err => err.msg));
                    return;
                }

                if(user.username === data.username) {
                    let userToLoin = {
                        username: user.username,
                        password: user.password,
                    };
    
                    this.loginUser(userToLoin);
                }
            })
            .catch(console.log);
    }

    loginUser(user) {
        if(this.state.user.isLoggedIn) {
            console.log('You are already logged in. Please logout first!');
            return;
        }

        // TODO: login a user and set sessionStorage items username and token
        fetch('http://localhost:9999/auth/signin', {
            method: 'POST',
            body: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json',
            },
        })
            .then(response => response.json())
            .then((data) => {                
                if(data.errors) {
                    console.log(data.errors.map(err => err.msg));
                    return;
                }
                
                if(user.username === data.username && data.token) {                    
                    this.setState({
                        user: {
                            userId: data.userId,
                            username: data.username,
                            isLoggedIn: true,
                        },
                    })

                    sessionStorage.setItem('userId', data.userId);
                    sessionStorage.setItem('username', data.username);
                    sessionStorage.setItem('token', data.token);
                }
            })
            .catch(console.log);
    }

    logout(event) {
       // TODO: prevent the default state
       event.preventDefault();

       if(!this.state.user.isLoggedIn) {
        console.log('You are not logged in. Please login first!');
        return;
    }
    
       // TODO: delete the data from the sessionStorage
       sessionStorage.removeItem('userId');
       sessionStorage.removeItem('username');
       sessionStorage.removeItem('token');

       // TODO: update the state (user: null)
       this.setState({
           user: {
               userId: '',
               username: '',
               isLoggedIn: false,
           },
       })
    }

    componentWillMount() {
        // TODO: check if there is a logged in user using the sessionStorage 
        // (if so, update the state, otherwise set the user to null)

        // TODO: fetch all the games
        this.fetchAllGames()
            .catch(console.log);
    }

    createGame(game) {
        
        if(!this.state.user.isLoggedIn) {
            console.log('Please login first!');
            return;
        }

        // TODO: create a game using fetch with a post method, 
        // then fetch all the games and update the state
        fetch('http://localhost:9999/feed/game/create', {
            method: 'POST',
            body: JSON.stringify(game),
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + sessionStorage.getItem('token'),
            },
        })
            .then(response => response.json())
            .then(data => {
                if(data.errors) {
                    console.log(data.errors.map(err => err.msg));
                    return;
                }
                console.log(data);

                this.fetchAllGames();
            })
            .catch(console.log);
    }

    switchForm() {
        // TODO: switch the value of the loginForm property
        this.setState((prevState) => ({
            loginForm: !prevState.loginForm
        }));
    }

    fetchAllGames() {
        return fetch('http://localhost:9999/feed/games', {
            method: 'GET',
        })
            .then(response => response.json())
            .then(data => {
                this.setState({
                    games: data.games
                });
            });
    }

    render() {
        return (
            <main>
                <AppNav
                    user={this.state.user}
                    logout={this.logout.bind(this)}
                    switchForm={this.switchForm.bind(this)}
                    loginForm={this.state.loginForm}
                />
                <AppContent
                    registerUser={this.registerUser.bind(this)}
                    loginUser={this.loginUser.bind(this)}
                    games={this.state.games}
                    createGame={this.createGame.bind(this)}
                    user={this.state.user}
                    loginForm={this.state.loginForm}
                />
                <AppFooter/>
            </main>
        )
    }
}

export default App;


