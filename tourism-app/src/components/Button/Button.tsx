import React from 'react';

interface ButtonProps {
  children: React.ReactNode;
  onClick: () => void;
}

const Button: React.FC<ButtonProps> = ({ children, onClick }) => {
  return (
    <button 
      className="text-white bg-green-700 border-2 border-green-700 hover:bg-green-800 hover:border-green-800 focus:outline-none focus:ring-4 focus:ring-green-300 font-semibold text-xl px-8 py-4 text-center rounded-lg dark:bg-green-600 dark:border-green-600 dark:hover:bg-green-700 dark:hover:border-green-700 dark:focus:ring-green-800" 
      onClick={onClick}
    >
      {children}
    </button>
  );
};

export default Button;
