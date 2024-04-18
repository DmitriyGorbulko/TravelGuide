import { Avatar, Button, Container, Grid, Link, TextField, Typography } from '@mui/material';
import React, { useState } from 'react'
import { SignIn, SignUp } from '../api/requests/userRequests';

export default function Registrtion() {
  const [email, setEmail] = useState<string>();
  const [password, setPassword] = useState<string>();
  const [name, setName] = useState<string>();


  const handlerChangeEmail = (e: React.ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  }

  const handlerChangePassword = (e: React.ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  }

  const handlerChangeName = (e: React.ChangeEvent<HTMLInputElement>) => {
    setName(e.target.value);
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
        <TextField sx={{ mb: 2 }} id='email' value={email} variant='outlined' color='secondary' size='small' onChange={handlerChangeEmail}></TextField>
        <TextField sx={{ mb: 2 }} id='password' value={password} variant='outlined' color='secondary' size='small' onChange={handlerChangePassword}></TextField>
        <TextField sx={{ mb: 2 }} id='name' value={name} variant='outlined' color='secondary' size='small' onChange={handlerChangeName}></TextField>
        <Button variant='outlined' color='secondary' onClick={() => { SignUp(name, email, password) }}>Создать аккаунт</Button>
      </Grid>
    </Container>
  )
}
