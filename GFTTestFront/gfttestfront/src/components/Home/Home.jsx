import React, { Component } from 'react'
import axios from 'axios';
import { Button } from 'react-bootstrap';


class Home extends Component {
    state = {
        rawOrder: '',
        orderResponse: '',
        lastOrdersList: []
    }

    postDataHandler = () => {    
        this.setState({orderResponse: ''});
        const orderToPost = {
            rawOrder: document.getElementById("placeOrder").value            
        };              

        axios.post('https://localhost:44337/api/orders', orderToPost)
            .then(response => {
                document.getElementById("placeOrder").value =''; 
                this.setState({orderResponse: response.data.rawOrderResponse});  

                axios.get('https://localhost:44337/api/orders')
                .then(response => {                    
                    this.setState({lastOrdersList: response.data.rawOrderResponseList});    
                });
            });
    }

    render() {

        const _lastOrdersList = this.state.lastOrdersList.map(lastOrder => {
            return <p style={{borderTop: '1px solid gray', padding: '5px'}}>{lastOrder}</p>
        });

        return (
            <div className="homeComponent">
                           
                <input type="text" id="placeOrder" placeholder="Place your order here..."/>
                <p></p>
                
                <Button onClick={this.postDataHandler}>Place Order</Button>                           
                <p></p>

                <input type="text" id="placedOrder" value={this.state.orderResponse} readOnly/>         
                <br/> 
                <br/>                 
                
                {_lastOrdersList}      
            </div>  
        )
    }
}

export default Home;