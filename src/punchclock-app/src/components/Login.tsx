import React, { useState, useContext } from 'react';
import {
  TextField, Button, Typography, Paper,
} from '@material-ui/core';
import styled from 'styled-components';
import { useHistory } from 'react-router-dom';
import useLogin from '../hooks/useLogin';
import { AuthContext } from '../providers/AuthProvider';

const StyledPaper = styled(Paper)`
  width: 100%;
  max-width: 640px;
  margin: 20px auto;
  padding: 20px;
`;

const Row = styled.div`
  margin: 10px 0;
`;

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
      <StyledPaper>
        <Row>
          <Typography variant="h5">Login</Typography>
        </Row>
        {error && <Typography color="secondary">{error}</Typography>}
        <Row>
          <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} type="email" fullWidth />
        </Row>
        <Row>
          <TextField label="Password" value={password} onChange={(e) => setPassword(e.target.value)} type="password" fullWidth />
        </Row>
        <Row>
          <Button type="submit" fullWidth color="primary" variant="contained">Login</Button>
        </Row>
      </StyledPaper>
    </form>
  );
};

export default Login;
