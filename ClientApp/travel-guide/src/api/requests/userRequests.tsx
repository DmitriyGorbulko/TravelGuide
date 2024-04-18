import axios from "axios";
import { baseUrl } from "./API";

export interface PropsSignIn {
    emailRequest: string | undefined;
    passwordRequest: string | undefined;
}

export interface PropsSignUp {
    emailRequest: string | undefined;
    passwordRequest: string | undefined;
    nameRequest : string | undefined;
}

export const SignUp = (nameRequest : string | undefined, emailRequest: string | undefined , passwordRequest: string | undefined) => {
    axios.post(`${baseUrl}/sign_up`, {
        name : nameRequest,
        email: emailRequest,
        password: passwordRequest
    })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
}

export const SignIn = (emailRequest: string | undefined , passwordRequest: string | undefined) => {
    axios.post(`${baseUrl}/sign_in`, {
        email: emailRequest,
        password: passwordRequest

    })
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });
}