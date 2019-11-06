import React, {
  createContext, useState,
} from 'react';

type State = {
  token: string | null,
  expiration: Date | null,
  authenticate: (token: string, expiration: string) => void,
  isAuthenticated: boolean,
  logout: () => void;
}

const initialState: State = {
  token: null,
  expiration: null,
  authenticate: () => {},
  isAuthenticated: false,
  logout: () => {},
};


export const AuthContext = createContext(initialState);

const localStorageToken = localStorage.getItem('token');
const localStorageExpiration = localStorage.getItem('expiration');

const AuthProvider: React.FC = ({ children }) => {
  const [t, setToken] = useState<string | null>(localStorageToken);
  const [e, setExpiration] = useState<Date | null>(localStorageExpiration === null
    ? null
    : new Date(localStorageExpiration));

  const logout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('expiration');
    setToken(null);
    setExpiration(null);
  };

  const authenticate = (token: string, expiration: string) => {
    localStorage.setItem('token', token);
    localStorage.setItem('expiration', expiration);
    setToken(token);
    setExpiration(new Date(expiration));
  };

  const isAuthenticated = !!t && !!e && e > new Date();

  return (
    <AuthContext.Provider value={{
      token: t, expiration: e, authenticate, isAuthenticated, logout,
    }}
    >
      {children}
    </AuthContext.Provider>
  );
};


export default AuthProvider;
