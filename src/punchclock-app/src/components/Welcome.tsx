import React from 'react';
import { Typography, makeStyles, Link as MaterialLink } from '@material-ui/core';
import { Link } from 'react-router-dom';


const useStyles = makeStyles({
  wrapper: {
    margin: '20px',
  },
  title: {
    marginBottom: '20px',
  },
});

const Welcome: React.FC = () => {
  const classes = useStyles();
  return (
    <div className={classes.wrapper}>
      <Typography variant="h2" className={classes.title}>Welcome to Punchclock!</Typography>
      <Typography>
        <MaterialLink component={Link} to="/login">Login</MaterialLink>
        {' '}
or
        {' '}
        <MaterialLink component={Link} to="/sign-up">create an account</MaterialLink>
        {' '}
to get started
      </Typography>
    </div>
  );
};

export default Welcome;
