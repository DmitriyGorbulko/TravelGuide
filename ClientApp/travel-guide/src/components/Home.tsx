import { YMaps, Map } from '@pbe/react-yandex-maps'
import React from 'react'

export default function Home ()  {
  return (
    <YMaps>
      <Map defaultState={{ center: [55.751574, 37.573856], zoom: 9 }} />
    </YMaps>
)}
