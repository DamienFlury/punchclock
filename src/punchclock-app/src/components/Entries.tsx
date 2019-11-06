import React from 'react';
import { Typography } from '@material-ui/core';
import EntriesList from './EntriesList';

const Entries: React.FC = () => (
  <>
    <Typography variant="h4">Entries</Typography>
    <EntriesList />
  </>
);
export default Entries;
