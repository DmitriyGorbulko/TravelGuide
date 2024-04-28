import { Button } from '@mui/material'
import { YMaps, Map, Placemark, SearchControl, FullscreenControl, ObjectManager, Clusterer, ZoomControl, TypeSelector, RouteButton } from '@pbe/react-yandex-maps'
import React, { useRef, useState } from 'react'
import { Test } from '../api/requests/userRequests'
import { observer } from 'mobx-react-lite'
import { tokenStore } from '../stores/tokenStore'
import { MapContainer, Marker, Popup, TileLayer } from 'react-leaflet'
import { load } from '@2gis/mapgl'

const Home = observer(() => {
  const { jwt, SignInStore } = tokenStore;
  const position = [51.505, -0.09]
  var src = "https://api-maps.yandex.ru/v3/?apikey=1e536ee2-ed38-46c6-adae-7e9973e63dc7&lang=ru_RU";

  const mapState = { center: [55.76, 37.64], zoom: 10 };

  const [, setSearchControl] = useState<
    ymaps.control.SearchControl | undefined
  >();

  const handleClick = (e: any) => {
    console.log('Координаты клика:', e.get('coords'));
  };

  return (


    
 
    <div>
      {/* yandex */}
      <YMaps
    query={{
      apikey: '5b383675-0c20-4fe2-98a5-4b8a2a9e53f5',
      load: "Map,Placemark,control.ZoomControl,control.FullscreenControl,geoObject.addon.balloon",
    }} >
        <Map 
          style={{
            width: `500px`,
            height: `500px`
          }} 
          
          defaultState={{ 
            center: [55.751574, 37.573856], 
            zoom: 9 
          }}

          onClick={handleClick}
        >
          {/* <SearchControl/> */}
          <Placemark geometry={[55.751574, 37.573856] } />
          <FullscreenControl />
          <ZoomControl options={{ size: 'small', position: { top: 43, right: 10 } }} />
          <TypeSelector options={{ float: 'right' } as any} />
          <RouteButton options={{ float: "right" }} />
        </Map>

      </YMaps>
      <Button variant='outlined' color='secondary' onClick={() => { Test() }}>test</Button> 

      {/* leaflet */}
      {/* <MapContainer center={[51.505, -0.09]} zoom={13} scrollWheelZoom={false}>
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        <Marker position={[51.505, -0.09]}>
          <Popup>
            A pretty CSS3 popup. <br /> Easily customizable.
          </Popup>
        </Marker>
      </MapContainer> */}


      {/* yandex */}

      {/* <YMaps>
    <Map state={mapState}>

      <Placemark
        geometry={{
          coordinates: [55.751574, 37.573856]
        }}
        properties={{
          hintContent: 'Собственный значок метки',
          balloonContent: 'Это красивая метка'
        }}
        options={{
          iconLayout: 'default#image',
          iconImageHref: 'https://udoba.org/sites/default/files/h5p/content/56145/images/iconImage-63748fc5dad02.png',
          iconImageSize: [30, 42],
          iconImageOffset: [-3, -42]
        }}
      />

    </Map>
  </YMaps> */}

    </div>
  )
})

export default Home;
