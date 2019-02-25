import React from "react";
import RegisterForm from "./RegisterForm";
import LogInForm from "./LoginForm";
import CreateForm from "../Games/CreateForm";

class DynamicForm extends React.Component {
    render() {
        const { user, 
            registerUser, 
            loginUser, 
            loginForm, 
            createGame } = this.props;

        return (
            <div>
                <div>
                    {
                        /*TODO: render a form depending on wheather the loginForm property is true*/
                        user.isLoggedIn ?
                        <CreateForm createGame={createGame} /> :
                        loginForm ?
                        <LogInForm loginUser={loginUser} /> :
                        <RegisterForm registerUser={registerUser}/>
                    }
                </div>
            </div>
        )
    }
}

export default DynamicForm