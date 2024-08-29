import React from 'react';

interface ArrowButtonProps {
  direction: 'left' | 'right';
  onClick: () => void;
}

const ArrowButton: React.FC<ArrowButtonProps> = ({ direction, onClick }) => {
  return (
    <button
      onClick={onClick}
      className={`w-0 h-0 border-t-[16px] border-t-transparent border-b-[16px] border-b-transparent ${
        direction === 'left'
          ? 'border-r-[16px] border-r-[#B65172]'
          : 'border-l-[16px] border-l-[#B65172]'
      }`}
    />
  );
};

export default ArrowButton;
