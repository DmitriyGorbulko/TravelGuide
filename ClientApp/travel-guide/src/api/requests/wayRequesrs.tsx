import axios from "axios";
import { baseUrl } from "./API";


export interface Way {
    id: number,
    title: string,
    description: string,
}


export const GetWay = async (id: number | null): Promise<Way> => {
    try {
        const response = await axios.get(`${baseUrl}/get_way?id=${id}`);
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.log(error);
        throw error; // Пробросить ошибку для обработки в вызывающем коде
    }
}

export const GetWays = async (): Promise<Way[]> => {
    try {
        const response = await axios.get(`${baseUrl}/get_ways`)
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.log(error);
        throw error;
    };
}