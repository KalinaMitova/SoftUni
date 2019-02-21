import React, {Component} from 'react';
import './App.css';
import AppHeader from "./App/AppHeader";
import AppContent from "./App/AppContent";
import AppFooter from "./App/AppFooter";

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
        
        fetch('http://localhost:9999/auth/signup', {
            method: 'POST',
            body: JSON.stringify(user),
        }).then(response => response.json())
            .then((userData) => {

                let userToLoin = {
                    username: user.username,
                    password: user.password,
                };

                this.loginUser(userToLoin);
            });
    }

    loginUser(user) {
        // TODO: login a user and set sessionStorage items username and token
        
        this.setState({
            user: {
                userId: user.userId,
                username: user.username,
                isLoggedIn: true,
            },
        })

        sessionStorage.setItem('userId', user.userId);
        sessionStorage.setItem('username', user.username);
        sessionStorage.setItem('token', user.token);
    }

    logout(event) {
       // TODO: prevent the default state
       event.preventDefault();

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
        // TODO: check if there is a logged in user using the sessionStorage (if so, update the state, otherwise set the user to null)

       // TODO: fetch all the games
        fetch('http://localhost:9999/feed/games', {
            method: 'GET',
        })
            .then(response => response.json())
            .then(data => {
                this.setState({
                    games: data.games
                });
            });
    }

    createGame(data) {
        // TODO: create a game using fetch with a post method then fetch all the games and update the state 
    }

    switchForm() {
        // TODO: switch the value of the loginForm property
        this.setState((prevState) => ({
            loginForm: !prevState.loginForm
        }));
    }

    render() {
        return (
            <main>
                <AppHeader
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


