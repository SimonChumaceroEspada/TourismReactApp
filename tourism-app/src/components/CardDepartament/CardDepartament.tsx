import React from 'react';

interface CardProps {
  image: string;
  alt: string;
}

const Card: React.FC<CardProps> = ({ image, alt }) => {
  return (
    <div className="w-64 h-96 p-4">
      <img
        src={image}
        alt={alt}
        className="w-full h-full object-cover rounded-lg shadow-lg"
      />
    </div>
  );
};

export default Card;
