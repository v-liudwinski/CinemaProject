import React from 'react';

interface Props {
  message: string;
}

const MyFunction: React.FC<Props> = ({ message }) => {
  return <div>{message}</div>;
};

export default MyFunction;