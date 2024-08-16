import React from 'react';

const Flag: React.FC = () => {
  return (
    <div className="flex flex-col h-4">
      <div className="bg-[#B65172] h-1/3"></div>
      <div className="bg-yellow-500 h-1/3"></div>
      <div className="bg-green-500 h-1/3"></div>
    </div>
  );
};

export default Flag;
