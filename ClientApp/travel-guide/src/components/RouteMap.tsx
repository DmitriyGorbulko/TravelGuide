import React, { useRef } from 'react';
import { YMaps, Map,  } from '@pbe/react-yandex-maps';
import { YMapsApi } from '@pbe/react-yandex-maps/typings/util/typing';

const RouteMap: React.FC = () => {
  const mapRef = useRef<ymaps.Map | null>(null);

  const mapState = {
    center: [55.751244, 37.618423], // Центр карты (Москва)
    zoom: 10, // Масштаб карты
  };

  // Точки маршрута
  const points: [number, number][] = [
    [55.751244, 37.618423], // Точка A
    [55.755826, 37.6173],   // Точка B
    [55.7601, 37.620393],   // Точка C
  ];

  // Функция для добавления маршрута
  const addRoute = (ymaps: YMapsApi): void => {
    const multiRoute = new ymaps.multiRouter.MultiRoute(
      {
        referencePoints: points, // Массив с точками маршрута
        params: {
          routingMode: 'pedestrian', // Пешеходный маршрут
        },
      },
      {
        boundsAutoApply: true, // Автоматическая подгонка карты под маршрут
      }
    );

    mapRef.current?.geoObjects.add(multiRoute);
  };

  return (
    <div style={{ width: '100%', height: '500px' }}>
      <YMaps query={{ apikey: '5b383675-0c20-4fe2-98a5-4b8a2a9e53f5' }}>
        <Map
          modules={['multiRouter.MultiRoute']}
          state={mapState}
          instanceRef={(map) => (mapRef.current = map)}
          onLoad={(ymaps) => addRoute(ymaps)}
          width="100%"
          height="100%"
        />
      </YMaps>
    </div>
  );
};

export default RouteMap;
