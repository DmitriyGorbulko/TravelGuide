import { Box, Button, Grid,  Paper, styled } from '@mui/material'

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: 'center',
  color: theme.palette.text.secondary,
}));

const ListWay = () => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <Grid container spacing={2}>
        <Grid item xs={6} md={5}>
          {/* <Item>xs=6 md=5</Item>
          <Item>xs=6 md=5</Item>
          <Item>xs=6 md=5</Item>
          <Item>xs=6 md=5</Item> */}
          <Button> test</Button>
        </Grid>
      </Grid>
    </Box>
  );
}

export default ListWay;