import axios, { AxiosResponse } from "axios";
import { baseUrl } from "./API";
import { useContext } from "react";
import { tokenStore } from "../../stores/tokenStore";

export interface PropsSignIn {
    emailRequest: string | undefined;
    passwordRequest: string | undefined;
}

export interface PropsSignUp {
    emailRequest: string | undefined;
    passwordRequest: string | undefined;
    nameRequest : string | undefined;
}

export const SignUp = async (nameRequest : string | undefined, emailRequest: string | undefined , passwordRequest: string | undefined) => {
    var date = await axios.post(`${baseUrl}/sign_up`, {
        name : nameRequest,
        email: emailRequest,
        password: passwordRequest
    })
        .then(function (response) {
            console.log(response);
            if(response.status == 200){
                return 200;
            }
            else{
                return 400;
            }
        })
        .catch(function (error) {
            console.log(error);
            return 400;
        });
    return date;
}

export const SignIn = async (emailRequest: string | undefined , passwordRequest: string | undefined) => {
    await axios.create().post(`${baseUrl}/sign_in`, {
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

export const Test = async () => {
    const {jwt} = tokenStore;

    try {
        const test = await axios.get(`${baseUrl}/test_authorize`, {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        console.log(test);
        console.log(test.data);
    } catch (error) {
        console.error('Ошибка при выполнении запроса:', error);
    }
}
export const Test1 = async () => {
    const {jwt} = tokenStore;
    const test = await axios.create().get(`${baseUrl}/test_anonimous`);
    console.log(test.data);
}