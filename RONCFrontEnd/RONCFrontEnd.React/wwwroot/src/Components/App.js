import React, { Component } from 'react';

export default class App extends Component{
    constructor(props){
        super(props);
        this.state = { result: 'default'};
        fetch('http://localhost:8080/api/values/8')
            .then(response => response.json())
            //.then(jsonstring => console.log(JSON.parse(jsonstring)))
            .then(data => {
                // console.log('Data Is: ' + data);
                this.setState({result: data})})
            .catch(error => {
                // console.log("In the error");
                this.setState({ result: error})
            })
    }
    

    render(){
        return (
            <div>{this.state.result}</div>
        )
    }
}