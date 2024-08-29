import React from 'react';

interface CardProps {
  image: string;
  alt: string;
  isActive: boolean;
}

const Card: React.FC<CardProps> = ({ image, alt, isActive }) => {
  return (
    <div className={`
      ${isActive ? 'w-full h-96' : 'w-24 h-32'}
      transition-all duration-300 ease-in-out
      bg-white rounded-2xl shadow-lg overflow-hidden
      border-4 border-white
    `}>
      <img
        src={image}
        alt={alt}
        className="w-full h-full object-cover"
      />
    </div>
  );
};

export default Card;