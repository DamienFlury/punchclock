import React, { useState } from 'react';
import { TextField, Button } from '@material-ui/core';

type Props = {
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void
}

const AuthForm: React.FC<Props> = ({ onSubmit }) => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  return (
    <form onSubmit={onSubmit}>
      <TextField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} type="email" />
      <TextField label="Password" value={password} onChange={(e) => setPassword(e.target.value)} type="password" />
      <Button type="submit">Login</Button>
    </form>
  );
};

export default AuthForm;
