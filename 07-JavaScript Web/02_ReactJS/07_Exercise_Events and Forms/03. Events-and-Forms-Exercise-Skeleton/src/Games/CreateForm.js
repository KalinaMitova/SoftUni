import React from 'react';

class CreateForm extends React.Component {
    constructor(props) {
        super(props);
        
        this.state = {
            title: '',
            description: '',
            imageUrl: '',
        };

        this.onInputChangeHandler = this.onInputChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    onInputChangeHandler(event) {
        const name = event.target.name;
        const value = event.target.value;
        this.setState({
            [name]: value
        });
    }

    onSubmitHandler(event) {
        // TODO: prevent the default behaviour of the click event, 
        // call the createGame function and pass it the data from the form
        event.preventDefault();
        
        const game = {
            title: this.state.title,
            description: this.state.description,
            imageUrl: this.state.imageUrl,
        };

        this.props.createGame(game);
    }

    render(){
        return (
        <div className="create-form">
            <h1>Create game</h1>
            <form onSubmit={this.onSubmitHandler}>
                <label>Title</label>
                <input type="text" id="title" name="title" onChange={this.onInputChangeHandler}/>
                <label>Description</label>
                <textarea type="text" id="description" name="description" onChange={this.onInputChangeHandler}/>
                <label>ImageUrl</label>
                <input type="text" id="imageUrl" name="imageUrl" onChange={this.onInputChangeHandler}/>
                <input type="submit" value="Create"/>
            </form>
        </div>
    )}
};

export default CreateForm;

