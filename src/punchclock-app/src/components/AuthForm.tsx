import React, { useState } from 'react';
import {
  TextField, Button, Paper, Typography,
} from '@material-ui/core';
import styled from 'styled-components';
import { ApolloError } from 'apollo-boost';

const StyledPaper = styled(Paper)`
  width: 100%;
  max-width: 640px;
  margin: 20px auto;
  padding: 20px;
`;

const Row = styled.div`
  margin: 10px 0;
`;


type Props = {
  onSubmit: (email: string, password: string) => void,
  error: ApolloError | undefined
}

const AuthForm: React.FC<Props> = ({ onSubmit, error }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  return (
    <form onSubmit={(e) => {
      e.preventDefault();
      onSubmit(email, password);
    }}
    >
      <StyledPaper>
        <Row>
          <Typography variant="h5">Login</Typography>
        </Row>
        {error && <Typography color="secondary">Wrong credentials</Typography>}
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

export default AuthForm;
