import { Button, FormControl, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from '@mui/material'
import { YMaps, Map, Placemark, SearchControl, FullscreenControl, ObjectManager, Clusterer, ZoomControl, TypeSelector, RouteButton, RoutePanel, RouteEditor, GeoObject } from '@pbe/react-yandex-maps'
import React, { useEffect, useRef, useState } from 'react'
import { Test } from '../api/requests/userRequests'
import { observer } from 'mobx-react-lite'
import { tokenStore } from '../stores/tokenStore'
import { MapContainer, Marker, Popup, TileLayer } from 'react-leaflet'
import { load } from '@2gis/mapgl'
import { CreatePlace, GetTypePlaces, TypePlace } from '../api/requests/placeRequests'
import { WidthNormal } from '@mui/icons-material'
import Header from './Header'

const MapWay = observer(() => {
  const { jwt, SignInStore } = tokenStore;

  const [typePlace, setTypePlace] = useState<TypePlace[]>()
  const [title, setTitle] = useState<string>()
  const [typePlaceId, setTypePlaceId] = useState<number>()
  const [latitude, setLatitude] = useState<number>()
  const [longitude, setLongitude] = useState<number>()

  // chooseTypePlace = () => {

  // }

  useEffect(() => {
    const handlerRequestTypePlace = async () => {
        try {
            const response = await GetTypePlaces();
            setTypePlace(response);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }
    handlerRequestTypePlace();
})

const handlerChangeTitle = (e: React.ChangeEvent<HTMLInputElement>) => {
  setTitle(e.target.value);
}

// const handlerChangeTypePlaceId = (e: React.ChangeEvent<{ value: unknown }>) => {
//   setTypePlaceId((e.target.value as number));
// }

const handlerChangeTypePlaceId = (event: SelectChangeEvent<number | string>) : number | undefined => {
  setTypePlaceId(event.target.value as number);
  return typePlaceId;
};

const handlerChangeLatitude = (e: React.ChangeEvent<HTMLInputElement>) => {
  setLatitude(parseFloat(e.target.value));
}

const handlerChangeLongitude = (e: React.ChangeEvent<HTMLInputElement>) => {
  setLongitude(parseFloat(e.target.value));
}

const handlerCreatePlace = () => {
  console.log(title, typePlaceId, latitude, longitude);
  CreatePlace(title, typePlaceId, latitude, longitude);
}

  return (
    <div>
      <Header/>
      <TextField 
                    sx={{mb: 2}} 
                    id='title' 
                    label="Title"
                    value={title} 
                    variant='outlined' 
                    color='secondary' 
                    size='small' 
                    onChange={handlerChangeTitle}
      />

      
    <FormControl size='small' >
      <InputLabel id="place-select-label">Тип места</InputLabel>
      <Select
        labelId="place-select-label"
        id="place-select"
        value={typePlaceId}
        onChange={handlerChangeTypePlaceId}
        label="Тип места"
      >
        {typePlace?.map((item) => (
          <MenuItem key={item.id} value={item.id}>
            {item.title}
          </MenuItem>
        ))}
      </Select>
    </FormControl>

      <TextField 
                    id='latitude' 
                    label="Latitude"
                    value={latitude} 
                    variant='outlined' 
                    color='secondary' 
                    size='small' 
                    onChange={handlerChangeLatitude}
      />

      <TextField 
                    id='longitude' 
                    label="longitude"
                    value={longitude} 
                    variant='outlined' 
                    color='secondary' 
                    size='small' 
                    onChange={handlerChangeLongitude}
      />
      <Button variant='outlined' color='secondary'onClick= { handlerCreatePlace }>Создать</Button>
    </div>
  )

  })
  
  
  
  export default MapWay;
  
  // const position = [51.505, -0.09]
  // var src = "https://api-maps.yandex.ru/v3/?apikey=1e536ee2-ed38-46c6-adae-7e9973e63dc7&lang=ru_RU";

  // const mapState = { center: [55.76, 37.64], zoom: 10 };

  // const [, setSearchControl] = useState<
  //   ymaps.control.SearchControl | undefined
  // >();

  // const handleClickMap = (e: any) => {
  //   console.log('Координаты клика:', e.get('coords'));
  //   console.log(e.get('target'));

    
  // }

  // const deliveryAddress = "Улица Пушкина, дом Колотушкина"; // Адрес доставки
  // const deliveryCoordinates = [55.751574, 37.573856]; // Координаты доставки

  // return (
  //   <div>
  //     {/* yandex */}
  //   <YMaps
  //     query={{
  //       apikey: '5b383675-0c20-4fe2-98a5-4b8a2a9e53f5',
  //       load: "package.full",
  //     }} >
  //       <Map
  //         style={{
  //           width: `500px`,
  //           height: `500px`
  //         }}

  //         defaultState={{
  //           center: [55.751574, 37.573856],
  //           zoom: 9
  //         }}

  //         onClick={handleClickMap}
  //       >
  //         {/* <SearchControl/> */}
  //         <Placemark
  //           geometry={[55.751574, 37.573856]}
  //           onClick={handleClickMap}
  //         />
  //         <RouteButton options={{ float: "right" }} />
  //       </Map>

  //     </YMaps>
  //     {/* <Button variant='outlined' color='secondary' onClick={() => { Test() }}>test</Button> */}



  //     {/* yandex */}

  //     {/* <YMaps>
  //   <Map state={mapState}>

  //     <Placemark
  //       geometry={{
  //         coordinates: [55.751574, 37.573856]
  //       }}
  //       properties={{
  //         hintContent: 'Собственный значок метки',
  //         balloonContent: 'Это красивая метка'
  //       }}
  //       options={{
  //         iconLayout: 'default#image',
  //         iconImageHref: 'https://udoba.org/sites/default/files/h5p/content/56145/images/iconImage-63748fc5dad02.png',
  //         iconImageSize: [30, 42],
  //         iconImageOffset: [-3, -42]
  //       }}
  //     />

  //   </Map>
  // </YMaps> */}

  //   </div>
  // )