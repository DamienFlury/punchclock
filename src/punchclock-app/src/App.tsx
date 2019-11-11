import React, { useContext } from 'react';
import './App.css';
import { MuiThemeProvider, createMuiTheme, CssBaseline } from '@material-ui/core';
import {
  blue, red, grey, pink,
} from '@material-ui/core/colors';
import ApolloClient, { Resolvers } from 'apollo-boost';
import { ApolloProvider } from '@apollo/react-hooks';
import {
  BrowserRouter, Route, Switch, Redirect,
} from 'react-router-dom';
import { StylesProvider } from '@material-ui/core/styles';
import Home from './components/Home';
import NavBar from './components/NavBar';
import Welcome from './components/Welcome';
import { AuthContext } from './providers/AuthProvider';
import Entries from './components/Entries';
import AuthForm from './components/AuthForm';
import EditEntry from './components/EditEntry';


const resolvers: Resolvers = {
  EntryType: {
    checkIn: (parent) => new Date(parent.checkIn),
    checkOut: (parent) => new Date(parent.checkOut),
  },
};

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
  resolvers,
});

type AuthenticatedRouteProps = {
  isAuthenticated: boolean,
  path: string,
}

const AuthenticatedRoute: React.FC<AuthenticatedRouteProps> = ({
  isAuthenticated,
  children, path,
}) => (
  <Route path={path}>
    {isAuthenticated ? (
      children
    ) : (
      <Redirect to="/" />
    )}
  </Route>
);

const App: React.FC = () => {
  const { isAuthenticated, isAdmin } = useContext(AuthContext);
  const theme = createMuiTheme({
    palette: {
      primary: isAdmin ? red : blue,
      type: 'dark',
      secondary: isAdmin ? grey : pink,
    },
  });

  return (
    <StylesProvider injectFirst>
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
                <AuthForm isLogin />
              </Route>
              <Route path="/sign-up">
                <AuthForm />
              </Route>
              <AuthenticatedRoute isAuthenticated={isAuthenticated} path="/entries">
                <Entries />
              </AuthenticatedRoute>
              <Route path="/edit-entry/:id">
                <EditEntry />
              </Route>
            </Switch>
          </BrowserRouter>
        </MuiThemeProvider>
      </ApolloProvider>
    </StylesProvider>
  );
};

export default App;
