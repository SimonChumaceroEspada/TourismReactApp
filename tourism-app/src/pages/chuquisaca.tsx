import React, { useState } from 'react';
import Header from '../components/Header/Header';
import Flag from '../components/Flag/Flag'; 
import Tabs from '../components/Tabs/Tabs';
import Description from '../components/Description/Description';
import Card from '../components/CardDepartament/CardDepartament';
import ArrowButton from '../components/ButtonsDepartament/ButtonsDepartament'; 

const images = [
  { src: 'image1.jpg', alt: 'Castle of Gloriet' },
  { src: 'image2.jpg', alt: 'Interior' },
  { src: 'image3.jpg', alt: 'Courtyard' },
];

const Chuquisaca: React.FC = () => {
  const [currentIndex, setCurrentIndex] = useState(0);

  const handlePrev = () => {
    setCurrentIndex((prevIndex) => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
  };

  const handleNext = () => {
    setCurrentIndex((prevIndex) => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
  };

  return (
    <div className="bg-[#FFF8E1] font-['Arial', 'sans-serif'] min-h-screen flex flex-col">
      <Header onLanguageChange={() => {}} />
      <Flag />
      <main className="flex-1 flex flex-col overflow-y-auto p-8">
        <Tabs />
        <div className="flex flex-grow justify-center items-center mt-8">
          <div className="flex flex-row w-full max-w-screen-lg">
            {/* Description Section */}
            <div className="w-1/3 p-4">
              <Description />
            </div>
            
            {/* Card Section */}
            <div className="w-2/3 flex flex-col items-center">
              <div className="flex flex-grow justify-center items-center mb-4">
                <Card image={images[currentIndex].src} alt={images[currentIndex].alt} />
              </div>
              <div className="flex justify-center space-x-8 mt-4">
                <ArrowButton direction="left" onClick={handlePrev} />
                <ArrowButton direction="right" onClick={handleNext} />
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Chuquisaca;
