import React, { useState, useEffect, useRef } from 'react';
import Header from '../components/Header/Header';
import Card from '../components/Card/Card';
import CarouselButtons from '../components/CarrouselButtons/CarrouselButtons';
import useTouristicPlaces from '../hooks/useTouristicPlaces';
import { CardProps } from '../components/Card/Card.types';

const Home: React.FC = () => {
  const [activeCard, setActiveCard] = useState(0);
  const [language, setLanguage] = useState<'en' | 'es'>('en'); 
  const touristicPlaces = useTouristicPlaces();
  const carouselRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const carousel = carouselRef.current;
    if (carousel) {
      carousel.style.transition = 'transform 0.5s ease'; 
      carousel.style.transform = `translateX(-${activeCard * 100}%)`;
    }
  }, [activeCard]);

  const handleCardChange = (index: number) => {
    setActiveCard(index);
  };

  const handleLanguageChange = () => {
    setLanguage((prev) => (prev === 'en' ? 'es' : 'en'));
  };

  return (
    <div className="bg-[#FFF8E1] font-['Arial', 'sans-serif'] flex flex-col min-h-screen">
      <Header onLanguageChange={handleLanguageChange} />
      <div className="bg-[#D32F2F] h-[10px]"></div>
      <div className="bg-[#FBC02D] h-[10px]"></div>
      <div className="bg-[#388E3C] h-[10px]"></div>
      <main className="flex flex-grow overflow-hidden">
        <div className="flex flex-1">
   
          <div className="flex flex-col items-center justify-center w-1/2 p-8 relative">
            <div className="relative w-full flex flex-col items-center overflow-hidden">
              <div ref={carouselRef} className="flex">
                {touristicPlaces.map((place, index) => (
                  <div
                    key={place.id}
                    className={`flex-shrink-0 w-full h-full flex items-center justify-center ${
                      index === activeCard ? 'scale-100' : 'scale-0'
                    } transition-transform duration-500`}
                  >
                    <Card
                      title={language === 'en' ? place.engName : place.espName}
                      description={language === 'en' ? place.engDescription : place.espDescription}
                      imageSrc={place.image}
                    />
                  </div>
                ))}
              </div>
              <div className="flex space-x-2 mt-6">
                <CarouselButtons
                  totalCards={touristicPlaces.length}
                  activeCard={activeCard}
                  onChange={handleCardChange}
                />
              </div>
            </div>
          </div>
          {/* Sección derecha con el botón */}
          <div className="flex items-center justify-center w-1/2 p-8">
            <button className="bg-[#209674] hover:bg-[#1E8E7E] text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline shadow-md transform hover:scale-105 transition duration-300">
              Explore More about Bolivia
            </button>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Home;
