import React from 'react';
import { shallow } from 'enzyme';
import App from '../Components/App';
import "isomorphic-fetch";

describe('App', () => {
    it('should contain a div', () => {
        const component = shallow(<App />);

        expect(component.find('div').length).toBe(1);
    })
});




