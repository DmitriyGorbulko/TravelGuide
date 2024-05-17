
import { Button, Container, Grid, Input, TextField, TextareaAutosize, Typography } from '@mui/material'
import { observer } from 'mobx-react-lite'
import React, { useEffect, useState } from 'react'
import { tokenStore } from '../stores/tokenStore';
import { GetWay, GetWays, Way } from '../api/requests/wayRequesrs';

const Home = observer(() => {
    const [id, setId] = useState<number | null>(null);
    const [way, setWay] = useState<Way>()
    const [wayAll, setWayAll] = useState<Way[]>()

    const handlerChangeId = (e: React.ChangeEvent<HTMLInputElement>) => {
        const value = e.target.value;
        setId(value === '' ? null : parseInt(value));
    }

    // useEffect(() =>{
        
    // })

    const handlerRequestApiById = async () => {
        console.log(id);
        try {
            if (id != null) {
                const response = await GetWay(id);
                setWay(response);
            } else {
                setId(null);
            }
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }
    const handlerRequestWayAll = async () => {
        try {
            const response = await GetWays();
            setWayAll(response);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }
    const { jwt, SignInStore } = tokenStore;

    return (
        <Container>
            <Grid
                container
                direction="column"
                display="flex"
                alignItems="center"
                wrap='wrap'
                alignContent='center'
                minHeight='700px'
                my={1}
            >
                <Input
                    color='secondary'
                    onChange={handlerChangeId}
                />
                <Button
                    variant='outlined'
                    color='secondary'
                    onClick={handlerRequestApiById}
                >
                    Найти
                </Button>
                {way == null ? <div>маршруты не найдены</div> :
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
                </Button>
                {wayAll?.map((item) => (
                    <div>
                        <Typography key={item.id}
                            variant='h3'
                        >
                            {item.title}
                        </Typography>
                        <Typography
                            variant='h5'
                            whiteSpace={'pre-line'}
                        >
                            {item.description}
                        </Typography>
                        <Button
                            variant='outlined'
                            color='secondary'>
                            Изменить
                        </Button>
                    </div>
                ))}
            </Grid>
        </Container>
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