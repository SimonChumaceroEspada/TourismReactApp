import React from 'react';

interface CardDepartament {
  image: string;
  alt: string;
  size: 'large' | 'small';
}

const Card: React.FC<CardDepartament> = ({ image, alt, size }) => {
  return (
    <div
      className={`p-3 bg-white rounded-2xl shadow-lg ${
        size === 'large' ? 'w-[20rem] h-[25rem]' : 'w-[16rem] h-[22rem]'
      }`} 
    >
      <img
        src={image}
        alt={alt}
        className="w-full h-full object-cover rounded-xl"
      />
    </div>
  );
};

export default Card;
