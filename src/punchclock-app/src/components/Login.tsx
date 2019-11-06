import React, { useState, useContext } from 'react';
import { TextField, Button, Typography } from '@material-ui/core';
import { useHistory } from 'react-router-dom';
import useLogin from '../hooks/useLogin';
import { AuthContext } from '../providers/AuthProvider';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState<string | null>(null);

  const { push } = useHistory();

  const login = useLogin(email, password);

  const { authenticate } = useContext(AuthContext);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      const body = await login();
      const { token, expiration } = body.data.createToken;
      authenticate(token, expiration);
      push('/');
    } catch {
      setError('Invalid credentials');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      {error && <Typography color="secondary">{error}</Typography>}
      <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} type="email" />
      <TextField label="Password" value={password} onChange={(e) => setPassword(e.target.value)} type="password" />
      <Button type="submit">Login</Button>
    </form>
  );
};

export default Login;
