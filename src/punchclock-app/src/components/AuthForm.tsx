import React, { useState, useContext } from 'react';
import {
  TextField, Button, Paper, Typography,
} from '@material-ui/core';
import styled from 'styled-components';
import { useMutation } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import { useHistory } from 'react-router-dom';
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

const CREATE_TOKEN = gql`
  mutation CreateToken($email: String!, $password: String!) {
    createToken(user: { email: $email, password: $password }) {
      token
      expiration
    }
  }
`;

const CREATE_USER = gql`
  mutation CreateUser($email: String!, $password: String!) {
    createUser(user: { email: $email, password: $password }) {
      token
      expiration
    }
  }
`;


type Props = {
  isLogin?: boolean
}

const AuthForm: React.FC<Props> = ({ isLogin = false }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const { push } = useHistory();

  const [login, { error }] = useMutation(isLogin ? CREATE_TOKEN : CREATE_USER);


  const { authenticate } = useContext(AuthContext);


  return (
    <form onSubmit={async (e) => {
      e.preventDefault();
      const body = await login({
        variables: {
          email,
          password,
        },
      });
      if (!error) {
        const { token, expiration } = isLogin ? body.data.createToken : body.data.createUser;
        console.log({ token, expiration });
        authenticate(token, expiration);
        push('/');
      }
    }}
    >
      <StyledPaper>
        <Row>
          <Typography variant="h5">{isLogin ? 'Login' : 'Sign up'}</Typography>
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
