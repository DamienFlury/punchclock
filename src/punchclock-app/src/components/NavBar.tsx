import React, { useContext } from 'react';
import {
  AppBar, Toolbar, Typography, Button,
} from '@material-ui/core';
import styled from 'styled-components';
import { NavLink } from 'react-router-dom';
import { AuthContext } from '../providers/AuthProvider';

const Spacer = styled.div`
  flex: 1;
`;

const StyledLink = styled(NavLink)`
  text-decoration: none;
  color: inherit;
`;

const NavBar: React.FC = () => {
  const { isAuthenticated, logout } = useContext(AuthContext);

  return (
    <AppBar position="sticky">
      <Toolbar>
        <Typography variant="h6">Punchclock</Typography>
        <StyledLink to="/">
          <Button color="inherit">Home</Button>
        </StyledLink>
        {isAuthenticated
        && (
        <StyledLink to="/entries">
          <Button color="inherit">Entries</Button>
        </StyledLink>
        )}
        <Spacer />
        {isAuthenticated ? <Button color="secondary" variant="contained" onClick={logout}>Logout</Button>
          : (
            <StyledLink to="/login">
              <Button color="secondary" variant="contained">
        Login
              </Button>
            </StyledLink>
          )}
      </Toolbar>
    </AppBar>
  );
};

export default NavBar;
