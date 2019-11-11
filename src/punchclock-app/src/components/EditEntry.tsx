import React from 'react';
import { useParams } from 'react-router-dom';

const EditEntry: React.FC = () => {
  const { id } = useParams();


  return <div>Hey</div>;
};

export default EditEntry;
