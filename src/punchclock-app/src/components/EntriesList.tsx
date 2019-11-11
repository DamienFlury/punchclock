import React, { useEffect } from 'react';
import { useQuery } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import {
  Typography, CircularProgress, Paper, Table, TableRow, TableCell, TableHead, TableBody,
} from '@material-ui/core';

type Entry = {
  id: number,
  checkIn: Date,
  checkOut: Date,
}

const EntriesList: React.FC = () => {
  // const { isAdmin } = useContext(AuthContext);
  const {
    error, loading, data, refetch,
  } = useQuery<{ entries: Entry[] }>(gql`
    query Entries {
      entries {
        id
        checkIn
        checkOut
      }
    }
  `);

  useEffect(() => {
    refetch();
  }, []);

  if (error) {
    return <Typography>Error</Typography>;
  }

  if (loading || !data) {
    return <CircularProgress />;
  }

  return (
    <Paper>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>
              <Typography>Id</Typography>
            </TableCell>
            <TableCell>
              <Typography>Check in</Typography>
            </TableCell>
            <TableCell>
              <Typography>Check out</Typography>
            </TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.entries.map((e) => (
            <TableRow key={e.id}>
              <TableCell>
                <Typography>{e.id}</Typography>
              </TableCell>
              <TableCell>
                <Typography>{e.checkIn}</Typography>
              </TableCell>
              <TableCell>
                <Typography>{e.checkOut}</Typography>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
};

export default EntriesList;
