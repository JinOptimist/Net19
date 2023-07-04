import './App.css';
import Header from './Header';
import React from 'react';
import Games from './components/games';
import axios from 'axios';
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './components/home';

function App() {

  axios.interceptors.request.use(function (config) {
    config.headers['Smile'] = localStorage.getItem('userId');
    return config;
  });

  return (
    <div>
      <BrowserRouter>
        <Header></Header>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/games" element={<Games />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;