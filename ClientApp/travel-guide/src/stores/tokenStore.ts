import { action, makeAutoObservable, makeObservable, observable } from 'mobx';
import { User } from './../api/models/User';
import { SignIn } from './../api/requests/userRequests';
import { stringify } from 'querystring'
import React from 'react'
import { baseUrl } from '../api/requests/API';
import axios from 'axios';

class TokenStore {
  jwt : string | null = null;

  constructor() {
    makeObservable(this, {
      jwt: observable,
      signInStore: action
    });
  }

  signInStore = async (email: string, password: string) => {

    const response = await axios.create().post(`${baseUrl}/sign_in`, {
      email: email,
      password: password

  });
    this.jwt = response.data;
    console.log(response);
    console.log(this.jwt);
  }
}

export const tokenStore =  new TokenStore();
