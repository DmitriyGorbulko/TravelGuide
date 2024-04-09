import React from 'react'
import Input from './input'
import { Avatar, Box, Button, Checkbox, Container, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography, createTheme, styled } from '@mui/material'
import { orange } from '@mui/material/colors';

export default function Login() {
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
            >
                <Typography component="h1" variant="h5">
                    Sign in
                </Typography>
                <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}></Avatar>
                <TextField variant='outlined' color='secondary' size='small' ></TextField>
                <TextField variant='outlined' color='secondary' size='small'></TextField>
                <Button variant='outlined' color='secondary'>Войти</Button>
                <Grid container>
                    <Grid item xs>
                        <Link href="#" variant="body2">
                            Забыли пароль?
                        </Link>
                    </Grid>
                    <Grid item>
                        <Link href="#" variant="body2">
                            {"Еще нет аккаунта? Зарегистрируйтесь"}
                        </Link>
                    </Grid>
                </Grid>
            </Grid>
        </Container>
       
    )
}

