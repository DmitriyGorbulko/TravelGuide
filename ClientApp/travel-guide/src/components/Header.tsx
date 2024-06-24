import { AccountCircle } from '@mui/icons-material'
import { Box, FormGroup, FormControlLabel, Switch, AppBar, Toolbar, IconButton, Typography, Menu, Avatar, Button, Container, Tooltip, Stack, SvgIcon, SvgIconProps } from '@mui/material'
import React from 'react'
import MenuIcon from '@mui/icons-material/Menu';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import { useNavigate } from 'react-router-dom';



function HomeIcon(props: SvgIconProps) {
  return (
    <SvgIcon {...props}>
      <path d="M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z" />
    </SvgIcon>
  );
}

const Header = () => {
  const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);
  const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

  const navigate = useNavigate();

  const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElNav(event.currentTarget);
  };
  const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseNavMenu = () => {
    setAnchorElNav(null);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const handlerClickCreateWay = () =>{
    handleCloseNavMenu();
    navigate(`/map_way`);
  }

  const handlerClickWayInProfile = () => {
    navigate(`/favorite_ways`);
  }

  const handlerClickWayIn = () => {
    navigate(`/`);
  }
  const handlerLogOut = () => {
    navigate(`/sign_in`);
  }

  return (
    <div>
      <AppBar position="static" color='secondary' >
        <Container maxWidth="xl">
          <Toolbar disableGutters>
            <Typography
              variant="h6"
              noWrap
              component="a"
              href="#app-bar-with-responsive-menu"
              sx={{
                mr: 2,
                display: { xs: 'none', md: 'flex' },
                fontFamily: 'monospace',
                fontWeight: 700,
                letterSpacing: '.3rem',
                color: 'inherit',
                textDecoration: 'none',
              }}
            >
              <HomeIcon sx={{ color: 'white' }} />
            </Typography>

            <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
              <IconButton
                size="large"
                aria-label="account of current user"
                aria-controls="menu-appbar"
                aria-haspopup="true"
                onClick={handleOpenNavMenu}
                color="inherit"
              >
                <MenuIcon />
              </IconButton>
            </Box>
            <AdbIcon sx={{ display: { xs: 'flex', md: 'none' }, mr: 1 }} />
            <Typography
              variant="h5"
              noWrap
              component="a"
              href="#app-bar-with-responsive-menu"
              sx={{
                mr: 2,
                display: { xs: 'flex', md: 'none' },
                flexGrow: 1,
                fontFamily: 'monospace',
                fontWeight: 700,
                letterSpacing: '.3rem',
                color: 'inherit',
                textDecoration: 'none',
              }}
            >
            </Typography>
            <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
             
                <Button
                  onClick={handlerClickWayInProfile}
                  sx={{ my: 2, color: 'white', display: 'block' }}
                >
                  Популярные маршруты
                </Button>
                <Button
                  onClick={handlerClickCreateWay}
                  sx={{ my: 2, color: 'white', display: 'block' }}
                >
                  Создать маршрут
                </Button>
            </Box>

            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: '45px' }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
               
                  <MenuItem onClick={handleCloseUserMenu}>
                    <Typography textAlign="center" >Профиль</Typography>
                  </MenuItem> 
                  <MenuItem onClick={handleCloseUserMenu}>
                    <Typography onClick={handlerClickWayIn} textAlign="center">Маршруты</Typography>
                  </MenuItem>
                  <MenuItem onClick={handleCloseUserMenu}>
                    <Typography onClick={handlerLogOut} textAlign="center">Выйти</Typography>
                  </MenuItem>
              </Menu>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>

    </div>
  )
}

export default Header