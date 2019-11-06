import React, { useState } from 'react';
import { useMutation } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import { TextField, Button } from '@material-ui/core';
import { useHistory } from 'react-router';

const Login: React.FC = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const { push } = useHistory();

  const [execute] = useMutation(gql`
    mutation CreateToken($email: String!, $password: String!) {
      createToken(user: { email: $email, password: $password }) {
        token
        expiration
      }
    }
  `, {
    variables: {
      email,
      password,
    },
  });
  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      const body = await execute();
      localStorage.setItem('token', body.data.createToken.token);
      push('/');
    } catch {
      console.log('OOF');
    }
  };
  return (
    <form onSubmit={handleSubmit}>
      <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} type="email" />
      <TextField label="Password" value={password} onChange={(e) => setPassword(e.target.value)} type="password" />
      <Button type="submit">Login</Button>
    </form>
  );
};

export default Login;
