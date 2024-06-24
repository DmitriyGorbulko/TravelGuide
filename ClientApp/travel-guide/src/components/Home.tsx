
import { Box, Button, Container, Dialog, DialogActions, DialogContent, DialogTitle, FormControl, Grid, Input, InputLabel, MenuItem, OutlinedInput, Select, SelectChangeEvent, TextField, TextareaAutosize, Typography } from '@mui/material'
import { observer } from 'mobx-react-lite'
import React, { useEffect, useState } from 'react'
import { tokenStore } from '../stores/tokenStore';
import { GetWay, GetWays, Way } from '../api/requests/wayRequesrs';
import { YMaps, Map, Placemark, SearchControl, FullscreenControl, ObjectManager, Clusterer, ZoomControl, TypeSelector, RouteButton, RoutePanel, RouteEditor, GeoObject } from '@pbe/react-yandex-maps'
import { APIProvider, MapControl, Marker } from '@vis.gl/react-google-maps';
import Header from './Header';


const Home = observer(() => {
    const [id, setId] = useState<number | null>(null);
    const [way, setWay] = useState<Way>()
    const [wayAll, setWayAll] = useState<Way[]>()
    const [openAddPoint, setOpenAddPoint] = useState<boolean>(false)
    const [xPoint, setXPoint] = useState<string>()
    const [yPoint, setYPoint] = useState<string>()

    const handlerChangeId = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setId(value === '' ? null : parseInt(value));
    }

    const handleClickOpen = (event: React.SyntheticEvent<unknown>, reason?: string) => {
        setOpenAddPoint(true);
    };

    const handleClickClose = (event: React.SyntheticEvent<unknown>, reason?: string) => {
        if (reason !== 'backdropClick') {
            setOpenAddPoint(false);
        }
    };
    const handleClickAddPoint = (event: React.SyntheticEvent<unknown>, reason?: string) => {
        if (reason !== 'backdropClick') {
            console.log(xPoint, yPoint);
            setOpenAddPoint(false);
        }
    };

    // useEffect(() =>{
    useEffect(() => {
        const handlerRequestWayAll = async () => {
            try {
                const response = await GetWays();
                setWayAll(response);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        }
        handlerRequestWayAll();
    })


    const handlerChangeX = (e: React.ChangeEvent<HTMLInputElement>) => {
        setXPoint(e.target.value);
    }

    const handlerChangeY = (e: React.ChangeEvent<HTMLInputElement>) => {
        setYPoint(e.target.value);
    }


    const handlerWatchhWay = () => {
        
    }

    const { jwt, SignInStore } = tokenStore;

    return (
        <div>
            <Header/>
            <Container sx={{ width: `1900px` }} >
            <Grid
                container
                direction="row"
                display="flex"
                minHeight='700px'
                my={1}
            >
                {/* <Input
                    color='secondary'
                    onChange={handlerChangeId}
                /> */}
                {/* <Button
                    variant='outlined'
                    color='secondary'
                    onClick={handlerRequestApiById}
                >
                    Найти
                </Button> */}
                {/* {way == null ? <div>маршруты не найдены</div> :
                    <div>
                        <Typography
                            variant='h3'
                        >
                            {way?.title}
                        </Typography>
                        <Typography
                            variant='h5'
                        >
                            {way?.description}
                        </Typography>
                    </div>}
                <Button
                    variant='outlined'
                    color='secondary'
                    onClick={handlerRequestWayAll}
                >
                    Показать все
                </Button> */}
                <Box sx={{ width: `60%` }}>
                    {wayAll?.map((item) => (
                        // <Box sx={{ wordWrap: 'break-word', whiteSpace: 'pre-wrap', width: '50%' }}>
                        <Grid
                            direction="column"
                            my={1}
                        >
                            <Typography key={item.id}
                                variant='body1'
                            >
                                {item.title}
                            </Typography>
                            <Typography
                                sx={{ wordWrap: 'break-word', whiteSpace: 'pre-wrap', width: '20%' }}
                                variant='body2'
                                // whiteSpace={'pre-line'}
                                gutterBottom

                            >
                                {item.description}
                            </Typography>
                            <Button
                                onClick={handleClickOpen}
                                variant='outlined'
                                color='secondary'>
                                Изменить
                            </Button>
                            <Dialog disableEscapeKeyDown open={openAddPoint} onClose={handleClickClose}>
                                <DialogTitle>Fill the form</DialogTitle>
                                <DialogContent>
                                    <Box component="form" sx={{ display: 'flex', flexWrap: 'wrap' }}>
                                        <FormControl sx={{ m: 1, minWidth: 120 }}>
                                            <InputLabel htmlFor="demo-dialog-native" />
                                            <TextField
                                                sx={{ mb: 2 }}
                                                id='x'
                                                label="X"
                                                value={xPoint}
                                                type="email"
                                                variant='outlined'
                                                color='secondary'
                                                size='small'
                                                onChange={handlerChangeX}
                                            />
                                        </FormControl>
                                        <FormControl sx={{ m: 1, minWidth: 120 }}>
                                            <InputLabel id="demo-dialog-select-label"></InputLabel>
                                            <TextField
                                                sx={{ mb: 2 }}
                                                id='x'
                                                label="Y"
                                                value={yPoint}
                                                type="email"
                                                variant='outlined'
                                                color='secondary'
                                                size='small'
                                                onChange={handlerChangeY}
                                            />
                                        </FormControl>
                                    </Box>
                                </DialogContent>
                                <DialogActions>
                                    <Button variant='outlined' color='secondary' onClick={handleClickClose}>Cancel</Button>
                                    <Button variant='outlined' color='secondary' onClick={handleClickAddPoint}>Ok</Button>
                                </DialogActions>
                            </Dialog>
                            <Button
                                variant='outlined'
                                color='secondary'>
                                Показать маршрут
                            </Button>
                        </Grid >
                        // </Box>
                    ))}
                </Box>

                {/* <Box>
                <APIProvider apiKey={'AIzaSyDfFxU-gqxZEVVRR09aBWuH7sjvRLUTbYw'}>
                <Map
                    style={{ width: '2vw', height: '2vh' }}
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
                </Box> */}
            </Grid>
        </Container>
        </div>
        
    )
})

export default Home


// const Home = observer(() => {
//     const [id, setId] = useState<number | null>();
//     const handlerChangeId = (e: React.ChangeEvent<HTMLInputElement>) => {
//         var value = e.target.value;
//         setId(value === null ? null : parseInt(value));
//         console.log(id);
//     }

//     const {jwt, SignInStore} = tokenStore;
//     return (

//         <Container>
//             {jwt ? ( <Grid
//                 container
//                 direction="column"
//                 display="flex"
//                 // justifyContent="center"
//                 alignItems="center"
//                 wrap='wrap'
//                 alignContent='center'
//                 minHeight='700px'
//                 my={1}
//             >
//                 <Input
//                     onChange={handlerChangeId}
//                 />
//                 <Button>{jwt}</Button>
//             </Grid>) : (<div>null</div>)}
//         </Container>
//     )
// })