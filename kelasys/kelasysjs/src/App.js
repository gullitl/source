import React from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from './actions/store';
import { Provider } from 'react-redux';
import DCandidates from './components/DCandidateForm';


function App() {
  return (
    <Provider store={store}>
      <DCandidates />
    </Provider>
  );
}

export default App;
