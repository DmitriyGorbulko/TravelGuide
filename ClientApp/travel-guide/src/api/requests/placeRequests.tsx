import axios from "axios";
import { baseUrl } from "./API";

export interface Place {
    id: number,
    title: string,
    typePlaceId: number,
    latitude: number;
    longitude: number;
}

export interface TypePlace{
    id: number,
    title: string,
}

export const CreatePlace = async (titleResponse : string | undefined, typePlaceResponse: number | undefined , latitudeResponse: number | undefined, longitudeResponse: number | undefined) => {
    console.log({titleResponse}, {typePlaceResponse}, {latitudeResponse}, {longitudeResponse});
    var date = await axios.post(`${baseUrl}/create_place`, {
        title : titleResponse,
        typePlace: typePlaceResponse,
        latitude: latitudeResponse,
        longitude: longitudeResponse
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


export const GetTypePlaces = async (): Promise<TypePlace[]> => {
    try {
        const response = await axios.get(`${baseUrl}/get_all_type_place`)
        console.log(response.data);
        return response.data;
    } catch (error) {
        console.log(error);
        throw error;
    };
}