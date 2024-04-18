import { action, makeAutoObservable, makeObservable, observable } from 'mobx';
import { User } from './../api/models/User';
import { SignIn } from './../api/requests/userRequests';
import { stringify } from 'querystring'
import React from 'react'

class tokenStore {
  jwt = "h";

  constructor() {
    makeObservable(this, {
      jwt: observable,
      signInStore: action
    })
  }
  signInStore(email: string, password: string) {
    var data = SignIn(email, password);
    this.jwt += "done";
    console.log(data);
  }
}

export default new tokenStore;
