import React, { useContext } from 'react';
import { useHistory } from 'react-router-dom';
import { useMutation } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import { AuthContext } from '../providers/AuthProvider';
import AuthForm from './AuthForm';

const Login: React.FC = () => {
  const { push } = useHistory();

  const [login, { error }] = useMutation(gql`
    mutation CreateToken($email: String!, $password: String!) {
      createToken(user: { email: $email, password: $password }) {
        token
        expiration
      }
    }
  `);


  const { authenticate } = useContext(AuthContext);

  const handleSubmit = async (email: string, password: string) => {
    const body = await login({
      variables: {
        email,
        password,
      },
    });
    if (!error) {
      const { token, expiration } = body.data.createToken;
      authenticate(token, expiration);
      push('/');
    }
  };

  return (
    <AuthForm onSubmit={handleSubmit} error={error} />
  );
};

export default Login;
