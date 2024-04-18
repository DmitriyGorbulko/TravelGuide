import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Registrtion from './components/Registrtion';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Login/>}/>
        <Route path='/sign_up' element={<Registrtion/>}/>
      </Routes>
    </BrowserRouter>

  );
}

export default App;
