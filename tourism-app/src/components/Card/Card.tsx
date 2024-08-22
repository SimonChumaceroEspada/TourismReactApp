import React from 'react';
import { CardProps } from './Card.types';

const Card: React.FC<CardProps> = ({ title, description, imageSrc }) => {
  return (
    <div className="bg-white rounded-3xl shadow-lg p-4 mb-8  w-full flex flex-col relative max-w-[550px] h-[650px]">
      <h1 className="text-xl md:text-2xl lg:text-3xl font-bold text-[#D32F2F] absolute top-0 left-1/2 transform -translate-x-1/2 mt-4 text-center w-full">
        Welcome to
      </h1>
      <img
        src={imageSrc}
        alt={title}
        className="w-full h-[50%] object-cover rounded-3xl mt-[3.5rem]"
      />
      <div className="flex flex-col items-center mt-1 flex-grow px-4">
        <h2 className="text-2xl md:text-4xl font-bold text-[#D32F2F] mb-2 text-center">
          {title}
        </h2>
        <p className="text-gray-800 text-sm md:text-base text-center">
          {description}
        </p>
      </div>
    </div>
  );
};

export default Card;
