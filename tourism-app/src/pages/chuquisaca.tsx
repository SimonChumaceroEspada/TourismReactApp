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
    <div className="bg-[#FFF8E1] font-sans min-h-screen flex flex-col">
      <Header onLanguageChange={() => {}} />
      <Flag />
      <main className="flex-1 flex flex-col p-6 max-w-6xl mx-auto w-full">
        <Tabs />
        <div className="flex flex-col md:flex-row justify-between items-center gap-8 h-[calc(100vh-300px)]">
          <div className="w-full md:w-1/3 h-full">
            <Description />
          </div>
          <div className="w-full md:w-2/3 flex flex-col items-center h-full">
            <div className="flex justify-between items-center w-full">
              {images.map((image, index) => (
                <div
                  key={index}
                  className={`transition-all duration-500 ${
                    index === currentIndex ? 'w-2/3 h-full' : 'w-1/6 h-full'
                  } ${
                    index === 0 ? 'order-1' : index === 1 ? 'order-2' : 'order-3'
                  }`}
                >
                  <Card 
                    image={image.src}
                    alt={image.alt}
                    isActive={index === currentIndex}
                  />
                </div>
              ))}
            </div>
            <div className="flex justify-center space-x-4 mt-4">
              <ArrowButton direction="left" onClick={handlePrev} />
              <ArrowButton direction="right" onClick={handleNext} />
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Chuquisaca;
