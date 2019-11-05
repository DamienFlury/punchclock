import React, { useState } from 'react';
import { Paper, Button } from '@material-ui/core';

const CheckInOut: React.FC = () => {
  const [isCheckedIn, setIsCheckedIn] = useState(false);

  const handleCheckIn = () => {
    setIsCheckedIn(true);
  };
  const handleCheckOut = () => {
    setIsCheckedIn(false);
  };

  return (
    <Paper>
      {isCheckedIn
        ? <Button onClick={handleCheckOut}>Check out</Button>
        : <Button onClick={handleCheckIn}>Check in</Button>}
    </Paper>
  );
};

export default CheckInOut;
