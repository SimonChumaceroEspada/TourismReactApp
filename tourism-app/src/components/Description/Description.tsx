import React from 'react';

const Description: React.FC = () => {
  return (
    <div className="flex flex-col justify-center h-full text-left">
      <h2 className="text-3xl font-semibold text-[#B65172] mb-4">Castle of Gloriet</h2>
      <p className="text-[#333333] text-sm">
        A whimsical castle near Sucre, Bolivia, built by self-proclaimed royalty. 
        Its eclectic architecture and rich history make it a must-see.
      </p>
    </div>
  );
};

export default Description;