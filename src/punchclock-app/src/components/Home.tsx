import React from 'react';
import { Typography } from '@material-ui/core';
import CheckInOut from './CheckInOut';

const Home: React.FC = () => (
  <div>
    <Typography variant="h1">Home</Typography>
    <Typography>Welcome to Punchclock!</Typography>
    <CheckInOut />
  </div>
);

export default Home;
