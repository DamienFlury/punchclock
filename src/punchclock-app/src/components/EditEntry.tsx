import React, { useState, useEffect } from 'react';
import { useParams, useHistory } from 'react-router-dom';
import { useQuery, useMutation } from '@apollo/react-hooks';
import { gql } from 'apollo-boost';
import {
  CircularProgress, Paper, TextField, Typography, Select, FormControl, InputLabel, MenuItem, Button,
} from '@material-ui/core';
import styled from 'styled-components';

type Employee = {
    id: string,
    email: string
}

type Entry = {
    id: number,
    checkIn: string,
    checkOut: string,
    employee: Employee,
}

const StyledWrapper = styled(Paper)`
  width: 100%;
  max-width: 720px;
  padding: 20px;
  margin: auto;
`;

const Row = styled.div`
  margin: 10px 0;
`;

const EditEntry: React.FC = () => {
  const { id } = useParams();

  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [employeeId, setEmployeeId] = useState('');

  const { push } = useHistory();

  const {
    error, loading, data, refetch,
  } = useQuery<{ entry: Entry, employees: Employee[] }>(gql`
        query Entries($id: Int) {
          entry(id: $id) {
            checkIn
            checkOut
            employee {
              id
              email
            }
          }
        }
      `, {
    variables: {
      id,
    },
  });

  const {
    error: empError, loading: empLoading, data: empData, refetch: empRefetch,
  } = useQuery<{ employees: Employee[] }>(gql`
    query {
      employees {
        id
        email
      }
    }
  `);

  const [updateEntry] = useMutation(gql`
    mutation UpdateEntry($entry: UpdateEntryInputType) {
      updateEntry(entry: $entry) {
        id
      }
    }
  `, {
    variables: {
      entry: {
        id,
        checkIn,
        checkOut,
        employeeId,
      },
    },
  });

  useEffect(() => {
    refetch().then((res) => {
      const { entry } = res.data;
      setCheckIn(entry.checkIn);
      setCheckOut(entry.checkOut);
      setEmployeeId(entry.employee.id);
    });
    empRefetch();
  }, []);

  if (loading || empLoading) {
    return <CircularProgress />;
  }

  if (error || !data || empError || !empData) {
    return <div>OOF</div>;
  }

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    updateEntry().then(() => {
      push('/');
    });
  };

  return (
    <StyledWrapper>
      <form onSubmit={handleSubmit}>
        <Row>
          <Typography variant="h4">Edit Entry</Typography>
        </Row>
        <Row>
          <TextField value={checkIn} onChange={(e) => setCheckIn(e.target.value)} label="Check in" fullWidth />
        </Row>
        <Row>
          <TextField value={checkOut} onChange={(e) => setCheckOut(e.target.value)} label="Check out" fullWidth />
        </Row>
        <Row>
          <FormControl fullWidth>
            <InputLabel>Department</InputLabel>
            <Select
              value={employeeId}
              onChange={(e) => setEmployeeId(e.target.value as string)}
              fullWidth
            >
              { empData.employees.map((e) => (
                <MenuItem value={e.id} key={e.id}>{e.email}</MenuItem>
              )) }
            </Select>
          </FormControl>
        </Row>
        <Row>
          <Button type="submit">Submit</Button>
        </Row>
      </form>
    </StyledWrapper>
  );
};

export default EditEntry;
