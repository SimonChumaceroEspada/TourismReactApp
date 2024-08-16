import React from 'react';

interface CarouselButtonsProps {
  totalCards: number;
  activeCard: number;
  onChange: (index: number) => void;
}

const CarouselButtons: React.FC<CarouselButtonsProps> = ({ totalCards, activeCard, onChange }) => {
  return (
    <div className="flex space-x-1 mt-4">
      {Array.from({ length: totalCards }).map((_, index) => (
        <button
          key={index}
          onClick={() => onChange(index)}
          className={`w-2 h-2 rounded-full ${
            index === activeCard ? 'bg-yellow-500' : 'bg-gray-400'
          } transition-colors duration-300`}
        />
      ))}
    </div>
  );
};

export default CarouselButtons;