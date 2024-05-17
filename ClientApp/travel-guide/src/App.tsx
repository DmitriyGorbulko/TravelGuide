import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Registrtion from './components/Registrtion';
import Header from './components/Header';
import ListWay from './components/ListWay';
import Test from './components/Test';
import MapWay from './components/MapWay';
import Home from './components/Home';
import { observer } from 'mobx-react-lite';
import { tokenStore } from './stores/tokenStore';

const App = observer(() => {
  const {jwt, SignInStore} = tokenStore;
  return (
    <BrowserRouter>
      <Header/>
      <Routes>
        {/*
        !!jwt ? <PrivateRoutes/> : <PublicRoutes/>
         */}
        <Route path='/' element={<Home/>}/>
        <Route path='/sign_in' element={<Login/>}/>
        <Route path='/sign_up' element={<Registrtion/>}/>
        <Route path='/map_way' element={<MapWay/>}/>
        <Route path='/way' element={<ListWay/>}/>
        <Route path='/test' element={<Test/>}/>
      </Routes>
    </BrowserRouter>
  );
})

export default App;
