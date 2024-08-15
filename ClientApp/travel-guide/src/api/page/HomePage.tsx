import React, { useEffect, useRef, useState } from 'react';
import { YMaps, Map, Button } from '@pbe/react-yandex-maps';
import { YMapsApi } from '@pbe/react-yandex-maps/typings/util/typing';
import CardWay from '../../components/CardWay';
import { GetWays, Way } from '../requests/wayRequesrs';
import { Container, Grid, Input, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const HomePage: React.FC = () => {
  const [wayAll, setWayAll] = useState<Way[]>()

  const navigate = useNavigate();

  const createWay = () =>{
    navigate(`/create_way`);
  }
  const handlerRequestWayAll = async () => {
    try {
      const response = await GetWays();
      setWayAll(response);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  }

  useEffect(() => {
    handlerRequestWayAll();
  })
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
        {/*                 
                <Button
                    variant='outlined'
                    color='secondary'
                    onClick={handlerRequestWayAll}
                >
                    Показать все
                </Button> */}
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
      <button onClick={createWay}>Create</button>
    </Container>
  );
};

export default HomePage;
