import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App';

const rootElement = document.getElementById('root');
// ReactDOM.render(rootElement, )
// document.getElementById('root').innerHTML='it worked';
console.log({rootElement});
ReactDOM.render(
    <App />,
    rootElement
);
