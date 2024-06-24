import { APIProvider, Map, MapControl, Marker } from '@vis.gl/react-google-maps'
import React from 'react'

const GoogleMap = () => {
    return (
        <div>
            <APIProvider apiKey={'AIzaSyDfFxU-gqxZEVVRR09aBWuH7sjvRLUTbYw'}>
                <Map
                    style={{ width: '100vw', height: '100vh' }}
                    defaultCenter={{ lat: 56.08312, lng: 40.22003 }}
                    defaultZoom={3}
                    gestureHandling={'greedy'}
                    disableDefaultUI={true}
                >
                    <Marker
                        position={{ lat: 53.54992, lng: 10.00678 }}
                    />
                </Map>

            </APIProvider>
        </div>
    )
}

export default GoogleMap