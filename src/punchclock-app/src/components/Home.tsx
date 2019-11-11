import React, { useContext } from 'react';
import { Typography } from '@material-ui/core';
import CheckInOut from './CheckInOut';
import { AuthContext } from '../providers/AuthProvider';
import AdminEntriesList from './AdminEntriesList';

const Home: React.FC = () => {
  const { isAdmin } = useContext(AuthContext);
  return (
    <div>
      <Typography variant="h1">Home</Typography>
      { isAdmin ? <AdminEntriesList /> : <CheckInOut /> }
    </div>
  );
};

export default Home;
