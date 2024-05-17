import React, { useState } from 'react';
import { YMaps, Map, Polyline, RouteButton } from '@pbe/react-yandex-maps';

const RouteMap: React.FC = () => {
    const [routePoints, setRoutePoints] = useState<number[][]>([]);
    const [showRouteButton, setShowRouteButton] = useState<boolean>(true);
    const [routing, setRouting] = useState<boolean>(false);

    const handleMapClick = (e: any) => {
        const coords = e.get('coords');
        setRoutePoints(prevPoints => [...prevPoints, coords]);
        setShowRouteButton(true);
    };

    const handleRouteButtonClick = () => {
        setRouting(true);
    };

    return (
        <YMaps
        query={{
            apikey: '5b383675-0c20-4fe2-98a5-4b8a2a9e53f5',
            load: "package.full",
          }}>
            <Map
                onClick={handleMapClick}
                defaultState={{ center: [55.75, 37.57], zoom: 9 }}
                style={{ width: '100%', height: '400px' }}
            >
                {routePoints.length > 1 && (
                    <Polyline
                        geometry={routePoints}
                        options={{
                            strokeColor: '#000',
                            strokeWidth: 4,
                        }}
                    />
                )}
                {showRouteButton && (
                    <RouteButton options={{ float: 'right' }} onClick={handleRouteButtonClick} />
                )}
            </Map>
        </YMaps>
    );
};

export default RouteMap;