import React from 'react';
import './App.css';
import { MuiThemeProvider, createMuiTheme, CssBaseline } from '@material-ui/core';
import { blue } from '@material-ui/core/colors';
import Home from './components/Home';
import NavBar from './components/NavBar';

const theme = createMuiTheme({
  palette: {
    primary: blue,
    type: 'dark',
  },
});

const App: React.FC = () => (
  <>
    <MuiThemeProvider theme={theme}>
      <CssBaseline />
      <NavBar />
      <Home />
    </MuiThemeProvider>
  </>
);

export default App;
