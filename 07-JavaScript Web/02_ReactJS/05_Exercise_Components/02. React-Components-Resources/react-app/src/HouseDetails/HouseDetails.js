import React from 'react';
import './HouseDetails.css';

const houseDetails = function(props) {
    let house = props.house;
    
    if(house) {
        return (
            <div className="HouseDetails">
                <h2>{house.type}</h2>
                <div className="image">
                    <img src={house.imageUrl} alt="house" />                
                </div>
                <p>Description: {house.description}</p>
                <p>Price: {house.price}$</p>
            </div>
        )
    }

    return (
        <div className="HouseDetails">
            <h2>House details</h2>
            <p style={{textAlign: 'center'}}>Please, select a house!</p>
        </div>
    )        
}

export default houseDetails;