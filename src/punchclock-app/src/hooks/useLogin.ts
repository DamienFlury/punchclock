import { useMutation } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';

const useLogin = (email: string, password: string) => {
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

  return execute;
};

export default useLogin;
