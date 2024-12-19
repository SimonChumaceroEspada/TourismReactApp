import React from "react";
import { useLanguage } from "../../context/LanguageContext";

interface CardProps {
  name: string;
  description: string;
  imageSrc: string;
}

const Card: React.FC<CardProps> = ({ name, description, imageSrc }) => {
  const { language } = useLanguage();

  return (
    <div className="max-w-sm rounded overflow-hidden shadow-lg bg-white">
      <h1 className="text-3xl font-bold text-center py-4 text-[#B65172]">
        {language === "en" ? `Welcome to ${name}` : `Bienvenidos a ${name}`}
      </h1>
      <img
        className="w-full h-64 object-cover"
        src={imageSrc}
        alt={name}
      />
      <div className="px-6 py-4">
        <p className="text-gray-700 text-base">
          {language === "en" ? description : description}
        </p>
      </div>
    </div>
  );
};

export default Card;
