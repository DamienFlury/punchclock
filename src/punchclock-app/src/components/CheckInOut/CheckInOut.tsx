import React, { useState, useEffect } from 'react';
import {
  Paper, Button, CircularProgress, Typography,
} from '@material-ui/core';
import { gql } from 'apollo-boost';
import { useMutation, useQuery } from '@apollo/react-hooks';
import { formatDistance } from 'date-fns';

const CheckInOut: React.FC = () => {
  const {
    data, error, loading, refetch,
  } = useQuery<{ lastCheckIn: Date | null }>(gql`
  query {
    lastCheckIn
  }`);

  const [now, setNow] = useState(new Date());

  useEffect(() => {
    const timeout = setTimeout(() => {
      setNow(new Date());
    }, 1000);
    return () => {
      clearTimeout(timeout);
    };
  }, [now]);

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
              {formatDistance(new Date(data.lastCheckIn), now)}
              {' '}
ago
            </Typography>
            <Button onClick={handleCheckInOut}>Check out</Button>
          </>
        )
        : <Button onClick={handleCheckInOut}>Check in</Button>}
    </Paper>
  );
};

export default CheckInOut;
