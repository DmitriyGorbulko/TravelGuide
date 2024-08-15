import { Link } from '@mui/material'
import React from 'react'

const  CardWay = (id : number, title : string, count : number, firstPlace : string, lastPlace : string) => {
  return (
    <div className='divCardWay'>
        <h1>{title}</h1>
        <h2>{count}</h2>
        <h2>{firstPlace}</h2>
        <h2>{lastPlace}</h2>
        <Link href='' className='linkCardWay'>test</Link>
    </div>
  )
}

export default CardWay