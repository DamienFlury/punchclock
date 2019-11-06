import React, { useContext } from 'react';
import './App.css';
import { MuiThemeProvider, createMuiTheme, CssBaseline } from '@material-ui/core';
import { blue } from '@material-ui/core/colors';
import ApolloClient from 'apollo-boost';
import { ApolloProvider } from '@apollo/react-hooks';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import Home from './components/Home';
import NavBar from './components/NavBar';
import Login from './components/Login';
import Welcome from './components/Welcome';
import { AuthContext } from './providers/AuthProvider';

const theme = createMuiTheme({
  palette: {
    primary: blue,
    type: 'dark',
  },
});

const client = new ApolloClient({
  uri: 'https://localhost:5001/graphql',
  request: (operation) => {
    const token = localStorage.getItem('token');
    operation.setContext({
      headers: {
        authorization: token ? `Bearer ${token}` : '',
      },
    });
  },
});

const App: React.FC = () => {
  const { isAuthenticated } = useContext(AuthContext);
  return (
    <ApolloProvider client={client}>
      <MuiThemeProvider theme={theme}>
        <CssBaseline />
        <BrowserRouter>
          <NavBar />
          <Switch>
            <Route path="/" exact>
              {isAuthenticated ? <Home /> : <Welcome />}
            </Route>
            <Route path="/Login">
              <Login />
            </Route>
          </Switch>
        </BrowserRouter>
      </MuiThemeProvider>
    </ApolloProvider>
  );
};

export default App;
