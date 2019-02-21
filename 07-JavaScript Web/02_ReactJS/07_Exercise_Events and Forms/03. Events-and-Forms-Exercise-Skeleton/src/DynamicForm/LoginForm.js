import React from 'react';
import './login.css';

class LogInForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
        };

        this.onInputChangeHandler = this.onInputChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onInputChangeHandler(event) {
        const name = event.target.name;
        const value = event.target.value;

        this.setState({ [name]: value });
    }

    onSubmitHandler(event) {
        // TODO: prevent the default behavior of the event and use the loginUser function by passing it the data from the form
        event.preventDefault();

        const user = {
            username: this.state.username,
            password: this.state.password,
        };

        this.props.loginUser(user);
    }

    render() {
        return (
            <div className="Login">
                <h1>Login</h1>
                <form onSubmit={this.onSubmitHandler}>
                    <label>Usersname</label>
                    <input type="text" id="usernameLogin" name="username" onChange={this.onInputChangeHandler}/>
                    <label>Password</label>
                    <input type="password" id="passwordLogin" name="password" onChange={this.onInputChangeHandler}/>
                    <input type="submit" value="Login"/>
                </form>
            </div>
        )
    }
}

export default LogInForm;
