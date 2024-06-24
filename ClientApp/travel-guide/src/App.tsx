import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/Login';
import { Navigate, BrowserRouter, Route, Routes  } from 'react-router-dom';
import Registrtion from './components/Registrtion';
import Header from './components/Header';
import ListWay from './components/ListWay';
import Test from './components/Test';
import MapWay from './components/MapWay';
import Home from './components/Home';
import { observer } from 'mobx-react-lite';
import { tokenStore } from './stores/tokenStore';
import GoogleMap from './components/GoogleMap';
import { FavoriteOutlined } from '@mui/icons-material';
import FavoriteWay from './components/FavoriteWay';

const App = () => {
  const {jwt, SignInStore} = tokenStore;
  return (
    <BrowserRouter>
      
      <Routes>
        {/*
        !!jwt ? <PrivateRoutes/> : <PublicRoutes/>
         */}
        {/* <Route path='/' element={!!jwt == null ? <Home/> : <Navigate to = "/sign_in"/>}/> */}
        <Route path='/' element={<Home/>}/>
        <Route path='/home' element={<Home/>}/>
        <Route path='/sign_in' element={<Login/>}/>
        <Route path='/sign_up' element={<Registrtion/>}/>
        <Route path='/map_way' element={ <MapWay/>}/>
        <Route path='/way' element={jwt == null ? <ListWay/> : <Navigate to = "/sign_in"/>}/>
        <Route path='/test' element={<Test/>}/>
        <Route path='/test2' element={<ListWay/>}/>
        <Route path='/favorite_ways' element={<FavoriteWay/>}/>

      </Routes>
    </BrowserRouter>
  );
}

export default observer(App);
