import React from 'react';
import { CardProps } from './Card.types';

const Card: React.FC<CardProps> = ({ title, description, imageSrc }) => {
  return (
    <div className="bg-white rounded-3xl shadow-2xl p-6 w-full sm:w-10/12 md:w-8/12 lg:w-6/12 h-[600px] flex flex-col relative">
      <img
        src={imageSrc}
        alt={title}
        className="w-full h-3/4 object-cover rounded-t-3xl"
      />
      <div className="mt-4 flex-grow">
        <h2 className="text-xl font-bold text-[#D32F2F]">{title}</h2>
        <p className="text-gray-800 text-sm mt-2">{description}</p>
      </div>
    </div>
  );
};

export default Card;
