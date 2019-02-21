import React from 'react';
import './register.css';

class RegisterForm extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            email: '',
            password: '',
        };

        this.onSubmitHandler = this.onSubmitHandler.bind(this);
        this.onInputChangeHandler = this.onInputChangeHandler.bind(this);
    }

    onSubmitHandler(event) {
        // TODO: prevent the default behavior of the event and use the registerUser function by passing it the data from the form
        event.preventDefault();
        const user = {
            username: this.state.username,
            email: this.state.email,
            password: this.state.password,
        };

        this.props.registerUser(this.state);
    }

    onInputChangeHandler(event) {
        const name = event.target.name;
        const value = event.target.value;
        
        this.setState({
            [name]: value
        });
    }

    render() {
        return (
            <div className="Register">
                <h1>Sign Up</h1>
                <form onSubmit={this.onSubmitHandler}>
                    <label>Username</label>
                    <input type="text" name="username" id="usernameReg" onChange={this.onInputChangeHandler}/>
                    <label>Email</label>
                    <input type="text" name="email" id="emailReg" onChange={this.onInputChangeHandler}/>
                    <label>Password</label>
                    <input type="password" name="password" id="passwordReg" onChange={this.onInputChangeHandler}/>
                    <input type="submit" value="Sign Up"/>
                </form>
            </div>
        )
    }
}
export default RegisterForm;