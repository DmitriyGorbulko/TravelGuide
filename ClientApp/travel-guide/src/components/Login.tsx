import React, { useState } from 'react'
import { Avatar, Box, Button, Checkbox, Container, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography, createTheme, styled } from '@mui/material'
import { orange } from '@mui/material/colors';
import { SignIn, Test, Test1 } from '../api/requests/userRequests';
import { observer } from 'mobx-react-lite';
import {tokenStore} from '../stores/tokenStore';
import { useNavigate } from 'react-router-dom';

const Login = observer(() => {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const navigate = useNavigate();
 
    const {jwt, SignInStore} = tokenStore;

    const handlerChangeEmail = (e: React.ChangeEvent<HTMLInputElement>) =>{
        setEmail(e.target.value);
    }

    const handlerChangePassword = (e: React.ChangeEvent<HTMLInputElement>) =>{
        setPassword(e.target.value);
    }

    const handleSubmit = (e:React.ChangeEvent<HTMLInputElement>) => {
        e.preventDefault();
        if (e.target.checkValidity()) {
          alert("Form is valid! Submitting the form...");
        } else {
          alert("Form is invalid! Please check the fields...");
        }
    };

    const onClickSignIn = async () =>{
        await SignInStore(email, password).then(()=> navigate(`/`));
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
                <Typography mt={5} component="h1" variant="h5">
                    Sign in
                </Typography>
                <Avatar sx={{ mb: 2, bgcolor: 'secondary.main' }}></Avatar>
                <TextField 
                    sx={{mb: 2}} 
                    id='email' 
                    label="Email"
                    type="email" 
                    value={email} 
                    variant='outlined' 
                    color='secondary' 
                    size='small' 
                    onChange={handlerChangeEmail}
                />
                <TextField 
                    sx={{mb: 2}}  
                    id="standard-password-input" 
                    label="Password" 
                    type="password" 
                    autoComplete="current-password"
                    value={password} 
                    variant='outlined' 
                    color='secondary' 
                    size='small'  
                    onChange={handlerChangePassword}
                />
                <Button variant='outlined' color='secondary'  onClick={onClickSignIn}>Войти</Button> 
                <Grid container direction={'column'} alignItems={'center'} mt={2} >
                    <Grid item xs>
                        <Link href="#" variant="body2">
                            Забыли пароль?
                        </Link> 
                    </Grid>
                    <Grid item mt={1}>
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