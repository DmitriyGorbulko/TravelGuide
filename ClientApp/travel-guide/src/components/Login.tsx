import React, { useState } from 'react'
import Input from './input'
import { Avatar, Box, Button, Checkbox, Container, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography, createTheme, styled } from '@mui/material'
import { orange } from '@mui/material/colors';
import { SignIn } from '../api/requests/userRequests';
import { observer } from 'mobx-react-lite';
import {tokenStore} from '../stores/tokenStore';

const Login = observer(() => {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
 
    const {jwt, signInStore} = tokenStore;

    const handlerChangeEmail = (e: React.ChangeEvent<HTMLInputElement>) =>{
        setEmail(e.target.value);
    }

    const handlerChangePassword = (e: React.ChangeEvent<HTMLInputElement>) =>{
        setPassword(e.target.value);
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
                <Typography component="h1" variant="h5">
                    Sign in
                </Typography>
                <Avatar sx={{ mb: 2, bgcolor: 'secondary.main' }}></Avatar>
                <TextField sx={{mb: 2}} id='email' value={email} variant='outlined' color='secondary' size='small' onChange={handlerChangeEmail}></TextField>
                <TextField sx={{mb: 2}} id='password' value={password} variant='outlined' color='secondary' size='small'  onChange={handlerChangePassword}></TextField>
                <Button variant='outlined' color='secondary' onClick={() => {signInStore(email, password) }}>Войти</Button>
                <Grid container mt={2}>
                    <Grid item xs>
                        <Link href="#" variant="body2">
                            Забыли пароль?
                        </Link>
                    </Grid>
                    <Grid item>
                        <Link href="/sign_up" variant="body2">
                            {"Еще нет аккаунта? Зарегистрируйтесь"}
                        </Link>
                    </Grid>
                </Grid>
            </Grid>
        </Container>
    )
})

export default Login;