import { Avatar, Box, Button, Checkbox, Container, CssBaseline, Grid, Link, TextField, ThemeProvider, Typography, createTheme, styled } from '@mui/material'
import React, { useEffect, useState } from 'react'
import { GetWay, GetWays } from '../api/requests/wayRequesrs'

export interface Ways{
    id: number
    title: string
    description: string
}


// const [ways, setWays] = useState<Ways>();

// useEffect(()=>{

// })

const handlerClick = () => {
    GetWay(1);
}


 
const ListWay = () => {
  return (
    <div>
        <Button  variant='outlined' color='secondary'  onClick={handlerClick}>List Way</Button> 
        <Button variant='outlined' color='secondary'  onClick={GetWays}> Way</Button> 
    </div>
    
  )
}

export default ListWay;