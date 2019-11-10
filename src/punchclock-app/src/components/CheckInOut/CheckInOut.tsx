import React from 'react';
import {
  Paper, Button, CircularProgress, Typography,
} from '@material-ui/core';
import { gql } from 'apollo-boost';
import { useMutation, useQuery } from '@apollo/react-hooks';

const CheckInOut: React.FC = () => {
  const {
    data, error, loading, refetch,
  } = useQuery<{ lastCheckIn: Date | null }>(gql`
  query {
    lastCheckIn
  }`);

  const [checkInOut] = useMutation(gql`
    mutation CheckIn {
      checkInOut {
        id
      }
    },
  `);
  if (loading) {
    return <CircularProgress />;
  }
  if (error || !data) {
    return <div>Error</div>;
  }

  const handleCheckInOut = async () => {
    await checkInOut();
    await refetch();
  };

  return (
    <Paper>
      {data.lastCheckIn
        ? (
          <>
            <Typography>
Last check in:
              {' '}
              {data.lastCheckIn}
            </Typography>
            <Button onClick={handleCheckInOut}>Check out</Button>
          </>
        )
        : <Button onClick={handleCheckInOut}>Check in</Button>}
    </Paper>
  );
};

export default CheckInOut;
