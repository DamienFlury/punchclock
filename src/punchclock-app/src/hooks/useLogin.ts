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
    update(cache, { data: createToken }) {
      const { token, expiration } = createToken.createToken;
      console.log('token', token);
      cache.writeQuery({
        query: gql`
          query {
            token
            expiration
          }
        `,
        data: { token, expiration },
      });
    },
  });

  return execute;
};

export default useLogin;
