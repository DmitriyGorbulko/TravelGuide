import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import { BrowserRouter, Route, Router, Routes } from 'react-router-dom';
import Registrtion from './components/Registrtion';
import Header from './components/Header';
import Test from './components/Test';
import MapWay from './components/MapWay';
import Home from './components/Home';
import { observer } from 'mobx-react-lite';
import { tokenStore } from './stores/tokenStore';
import CreateWay, { AddWay } from './components/AddWay';
import HomePage from './api/page/HomePage';
import RouteMap from './components/RouteMap';
import ListWay from './components/ListWay';

const App = observer(() => {
  const {jwt, SignInStore} = tokenStore;
  return (
    
    <BrowserRouter>
      <Routes>
        {/* <Header/>!!!!!!!!!!!! */}
        {/*
        !!jwt ? <PrivateRoutes/> : <PublicRoutes/>
         */}
        <Route path='/' element={<HomePage/>}/>
        <Route path='/sign_in' element={<Login/>}/>
        <Route path='/sign_up' element={<Registrtion/>}/>
        <Route path='/create_way' element={<AddWay/>}/>
        {/* <Route path='/map_way' element={<MapWay/>}/> */}
        {/* <Route path='/way' element={<ListWay/>}/> */}
        {/* <Route path='/test' element={<Test/>}/> */}
      </Routes>
    </BrowserRouter>
  );
})

export default App;
