import { Typography, Avatar, TextField, Container, Grid, createSvgIcon, Button } from '@mui/material';
import { YMaps, Placemark, RouteButton, Map } from '@pbe/react-yandex-maps'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { CreateWay } from '../api/requests/wayRequesrs';

export const AddWay = () => {

    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const navigate = useNavigate();

    const handleClickMap = (e: any) => {
        console.log('Координаты клика:', e.get('coords'));
        console.log(e.get('target'));
    }

    const handlerChangeTitle = (e: React.ChangeEvent<HTMLInputElement>) => {
        setTitle(e.target.value);
    }

    const handlerChangeDescription = (e: React.ChangeEvent<HTMLInputElement>) => {
        setDescription(e.target.value);
    }

    const onClickCreateWay = () => {
        CreateWay(title, description);
    }


    const PlusIcon = createSvgIcon(
        // credit: plus icon from https://heroicons.com/
        <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            strokeWidth={1.5}
            stroke="currentColor"
        >
            <path strokeLinecap="round" strokeLinejoin="round" d="M12 4.5v15m7.5-7.5h-15" />
        </svg>,
        'Plus',
    );
    return (
        <Container component='body' maxWidth="xs">
            <Grid
                container
                direction="column"
                display="flex"
                justifyContent="center"
                alignItems="center"
                wrap='wrap'
                alignContent='center'
                minHeight='700px'
                my={1}
            >
                <Typography mt={5} component="h1" variant="h5">
                    Создание маршрута
                </Typography>
                <Avatar sx={{background: "#9C27B0",mb: 2}}>
                    <PlusIcon  sx={{background: "#9C27B0"}} />
                </Avatar>
                <TextField
                    sx={{ mb: 2 }}
                    value={title}
                    label= 'Title'
                    variant='outlined'
                    color='secondary'
                    size='small'
                    onChange={handlerChangeTitle}
                />
                <TextField
                    sx={{ mb: 2 }}
                    value={description}
                    label='Description'
                    variant='outlined'
                    color='secondary'
                    size='small'
                    onChange={handlerChangeDescription}
                />
                <Button variant='outlined' color='secondary'  onClick={onClickCreateWay}>Создать</Button> 
            </Grid>
        </Container>



        //     {/* <Container component='body' maxWidth="xs">
        //         <Grid
        //             container
        //             direction="column"
        //             display="flex"
        //             alignItems="center"
        //             wrap='wrap'
        //             alignContent='center'
        //             minHeight='700px'
        //             my={1}>
        //             <TextField
        //                 sx={{ mb: 2 }}
        //                 value={email}
        //                 variant='outlined'
        //                 color='secondary'
        //                 size='small'
        //                 onChange={handlerChangeEmail}
        //             />
        //             <TextField
        //                 sx={{ mb: 2 }}
        //                 autoComplete="current-password"
        //                 variant='outlined'
        //                 color='secondary'
        //                 size='small'
        //                 onChange={handlerChangePassword}
        //             />
        //         </Grid>
        //     </Container> */}

        // {/* <div className='divMapCreateWay'>
        //     <YMaps
        //         query={{
        //             apikey: '5b383675-0c20-4fe2-98a5-4b8a2a9e53f5',
        //             load: "package.full",
        //         }} >
        //         <Map
        //             style={{
        //                 width: `500px`,
        //                 height: `500px`
        //             }}

        //             defaultState={{
        //                 center: [55.751574, 37.573856],
        //                 zoom: 9
        //             }}

        //             onClick={handleClickMap}
        //         >
        //             {/* <SearchControl/> */}
        // {/* <Placemark
        //                 geometry={[55.751574, 37.573856]}
        //                 onClick={handleClickMap}
        //             />
        //             <RouteButton options={{ float: "right" }} />
        //             <RouteButton />
        //         </Map>

        //     </YMaps>
        // </div> */}

    )
}

export default CreateWay