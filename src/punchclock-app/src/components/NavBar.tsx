import React from 'react';
import {
  AppBar, Toolbar, Typography, Button,
} from '@material-ui/core';

const NavBar: React.FC = () => (
  <AppBar position="sticky">
    <Toolbar>
      <Typography variant="h6">Punchclock</Typography>
      <Button color="inherit">Home</Button>
      <Button color="inherit">Entries</Button>
    </Toolbar>
  </AppBar>
);

export default NavBar;
