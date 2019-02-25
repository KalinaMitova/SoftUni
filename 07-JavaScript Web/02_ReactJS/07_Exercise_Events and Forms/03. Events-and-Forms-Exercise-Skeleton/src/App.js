import React, {Component} from 'react';
import './App.css';
import 'react-toastify/dist/ReactToastify.css';
import AppContent from "./App/AppContent";
import AppNav from './App/AppNav';
import { ToastContainer } from 'react-toastify';
import { toast } from 'react-toastify';

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
            toast.info('You are already logged in. Please logout first!', {
                position: toast.POSITION.TOP_RIGHT
            });
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
                    data.errors.forEach(err => {
                        toast.error(err.msg);
                    });
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
            toast.info('You are already logged in. Please logout first!', {
                position: toast.POSITION.TOP_RIGHT
            });
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
                console.log(data);             
                if(data.hasOwnProperty('message') && !data.hasOwnProperty('token')) {
                    toast.error(data.message, {
                        position: toast.POSITION.TOP_RIGHT
                    });
                    return;
                }
                
                if(user.username === data.username && data.token) {        
                    sessionStorage.setItem('userId', data.userId);
                    sessionStorage.setItem('username', data.username);
                    sessionStorage.setItem('token', data.token);

                    this.setState({
                        user: {
                            userId: data.userId,
                            username: data.username,
                            isLoggedIn: true,
                        },
                    });

                    toast.success(data.message, {
                        position: toast.POSITION.TOP_RIGHT
                    });
                }
            })
            .catch(console.log);
    }

    logout(event) {
        // TODO: prevent the default state
        event.preventDefault();

        if(!this.state.user.isLoggedIn) {
            toast.info('You are not logged in. Please login first!', {
                position: toast.POSITION.TOP_RIGHT
            });
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
        // TODO: fetch all the games
        this.fetchAllGames()
            .catch(console.log);
    }

    createGame(game) {
        
        if(!this.state.user.isLoggedIn) {
            toast.info('Please login first!', {
                position: toast.POSITION.TOP_RIGHT
            });
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
                    data.errors.forEach(err => {
                        toast.error(err.msg);
                    });
                    return;
                }

                toast.success("Game is created successfully.", {
                    position: toast.POSITION.TOP_RIGHT
                });

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
                    games: data.games,
                    hasFetched: true,
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
                <ToastContainer />               
                <AppContent
                    registerUser={this.registerUser.bind(this)}
                    loginUser={this.loginUser.bind(this)}
                    games={this.state.games}
                    createGame={this.createGame.bind(this)}
                    user={this.state.user}
                    loginForm={this.state.loginForm}
                />
            </main>
        )
    }
}

export default App;


