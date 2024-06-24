import React, { useState, useEffect } from 'react';
import { YMaps, Map, Polyline } from '@pbe/react-yandex-maps';

const YMap: React.FC = () => {
  const [mapInstance, setMapInstance] = useState<any>(null);
  const [route, setRoute] = useState<any>(null);

  const points: [number, number][] = [
    [55.751574, 37.573856], // Точка 1
    [55.751999, 37.615555], // Точка 2
    [55.757500, 37.615000], // Точка 3
  ];

  useEffect(() => {
    if (mapInstance && !route) {
      const ymaps = mapInstance.ymaps;
      const multiRoute = new ymaps.multiRouter.MultiRoute(
        {
          referencePoints: points,
          params: {
            routingMode: 'auto',
          },
        },
        {
          boundsAutoApply: true,
        }
      );

      setRoute(multiRoute);
      mapInstance.geoObjects.add(multiRoute);
    }
  }, [mapInstance, route]);

  return (
    <YMaps>
      <Map
        defaultState={{ center: [55.751574, 37.573856], zoom: 10 }}
        width="100%"
        height="400px"
        instanceRef={(ref) => ref && setMapInstance(ref)}
      />
    </YMaps>
  );
};

export default YMap;
