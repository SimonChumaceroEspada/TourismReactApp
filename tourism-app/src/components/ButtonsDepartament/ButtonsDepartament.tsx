import React from 'react';

interface ArrowButtonProps {
  direction: 'left' | 'right';
  onClick: () => void;
}

const ArrowButton: React.FC<ArrowButtonProps> = ({ direction, onClick }) => {
  return (
    <button
      onClick={onClick}
      className={`w-8 h-8 bg-gray-200 rounded-full flex items-center justify-center
        hover:bg-gray-300 transition-colors`}
    >
      <svg
        className={`w-4 h-4 text-gray-600 ${direction === 'left' ? 'transform rotate-180' : ''}`}
        fill="none"
        strokeLinecap="round"
        strokeLinejoin="round"
        strokeWidth="2"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path d="M9 5l7 7-7 7"></path>
      </svg>
    </button>
  );
};

export default ArrowButton;