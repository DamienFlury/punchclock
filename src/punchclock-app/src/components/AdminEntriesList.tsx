import React, { useEffect } from 'react';
import { useQuery } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import {
  Typography, Paper, CircularProgress, Table, TableHead, TableRow, TableCell, TableBody, Button,
} from '@material-ui/core';

type Entry = {
    id: number,
    checkIn: Date,
    checkOut: Date,
    employeeId: number,
}

const AdminEntriesList: React.FC = () => {
  const {
    error, loading, data, refetch,
  } = useQuery<{ entries: Entry[] }>(gql`
        query Entries {
          entries {
            id
            checkIn
            checkOut
            employeeId
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
              <TableCell>
                <Button color="primary">Edit</Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </Paper>
  );
};


export default AdminEntriesList;
