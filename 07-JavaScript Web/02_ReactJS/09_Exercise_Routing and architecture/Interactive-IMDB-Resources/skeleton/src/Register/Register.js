import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { toast } from 'react-toastify';

import './Register.css';

class Register extends Component {
  constructor(props) {
    super(props);

    this.state = {
      username: '',
      email: '',
      password: '',
    };

    this.onChangeHandler = this.onChangeHandler.bind(this);
    this.onSubmitHandler = this.onSubmitHandler.bind(this);
  }

  onChangeHandler(event) {
    const name = event.target.name;

    if(this.state.hasOwnProperty(name)) {
      const value = event.target.value;

      this.setState({
        [name]: value,
      })
    }
  }

  onSubmitHandler(event) {
    event.preventDefault();
    
    fetch('http://localhost:9999/auth/signup', {
      method: 'POST',
      body: JSON.stringify(this.state),
      headers: {
        'Content-Type': 'application/json'
      },
    })
      .then((response) => response.json())
      .then((data) => {
        
        if(this.state.username === data.username) {
          const userToLogin = {
            username: this.state.username,
            password: this.state.password,
          };

          this.props.login(userToLogin);
          
          toast.success(data.message);
        } else {
          toast.error(data.message);
          data.errors.forEach((err) => {
            toast.error(err.msg);
          });
        }
      })
      .catch(console.log);
  }

  render() {
    if(this.props.user.isLoggedIn) {
      return <Redirect to="/" />;
    }
    
    return (
      <div className="Register">
        <h1>Register</h1>
        <form onSubmit={this.onSubmitHandler}>
          <label htmlFor="username">Username</label>
          <input type="text" id="username" name="username" placeholder="Ivan Ivanov" onChange={this.onChangeHandler} value={this.state.username} />
          <label htmlFor="email">Email</label>
          <input type="text" id="email" name="email" placeholder="ivan@gmail.com" onChange={this.onChangeHandler} value={this.state.email} />
          <label htmlFor="password">Password</label>
          <input type="password" id="password" name="password" placeholder="******" onChange={this.onChangeHandler} value={this.state.password} />
          <input type="submit" value="Register" />
        </form>
      </div>
    );
  }
}

export default Register;
