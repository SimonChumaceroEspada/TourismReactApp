import React from 'react';
import { CardProps } from './Card.types';

const Card: React.FC<CardProps> = ({ title, description, imageSrc }) => {
  return (
    <div className="bg-white rounded-3xl shadow-card p-4 md:p-6 w-full max-w-lg sm:max-w-md md:max-w-xl lg:max-w-2xl h-[700px] flex flex-col relative">
      <div className="absolute top-4 left-6 text-left">
        <h1 className="text-sm font-bold text-[#D32F2F]">Welcome to</h1>
      </div>
      <img
        src={imageSrc}
        alt={title}
        className="w-full h-[350px] md:h-[400px] lg:h-[450px] object-cover rounded-t-3xl mt-12"
      />
      <div className="flex flex-col items-center mt-4 flex-grow px-4">
        <h2 className="text-xl md:text-2xl font-bold text-[#D32F2F] mb-2 text-center">{title}</h2>
        <p className="text-gray-800 text-sm md:text-base text-center">{description}</p>
      </div>
    </div>
  );
};

export default Card;


