import { Avatar, Button, Container, Grid, Link, TextField, Typography } from '@mui/material';
import React, { useState } from 'react'
import { SignIn, SignUp } from '../api/requests/userRequests';
import { useNavigate } from "react-router-dom";


export default function Registrtion() {
  const [email, setEmail] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [name, setName] = useState<string>();
  const navigate = useNavigate();

  const handlerChangeEmail = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  }

  const handlerChangePassword = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  }

  const handlerChangeName = (e: React.ChangeEvent<HTMLInputElement>) => {
    setName(e.target.value);
  }

  async function onCreateClick() {
    var code = await SignUp(name, email, password); 
    console.log(code); 
    if (code == 200){
      navigate(`/`);
    }
    
  }


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
        <Typography component="h1" variant="h5">Регистрация</Typography>
        <TextField
          sx={{ mb: 2 }}
          id='email'
          label="Name"
          value={email}
          variant='outlined'
          color='secondary'
          size='small'
          onChange={handlerChangeEmail}
        />
        <TextField
          sx={{ mb: 2 }}
          id='password'
          label="Email"
          value={password}
          variant='outlined'
          color='secondary'
          size='small'
          onChange={handlerChangePassword}
        />
        <TextField
          sx={{ mb: 2 }}
          id='name'
          label="Password"
          value={name}
          variant='outlined'
          color='secondary'
          size='small'
          onChange={handlerChangeName}
        />
        <Button 
          variant='outlined' 
          color='secondary' 
          onClick= { onCreateClick }
        >
          Создать аккаунт
        </Button>
      </Grid>
    </Container>
  )
}
