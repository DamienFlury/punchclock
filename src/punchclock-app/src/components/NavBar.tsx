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
`;

const NavBar: React.FC = () => {
  const { isAuthenticated } = useContext(AuthContext);

  return (
    <AppBar position="sticky">
      <Toolbar>
        <Typography variant="h6">Punchclock</Typography>
        <Button color="inherit">Home</Button>
        <Button color="inherit">Entries</Button>
        <Spacer />
        <StyledLink to="/login">
          {isAuthenticated || (
          <Button color="secondary" variant="contained">
        Login
          </Button>
          )}
        </StyledLink>
      </Toolbar>
    </AppBar>
  );
};

export default NavBar;
