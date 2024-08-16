import React, { useState } from 'react';
import Header from '../components/Header/Header';
import Card from '../components/Card/Card';
import CarouselButtons from '../components/CarrouselButtons/CarrouselButtons';
import useTouristicPlaces from '../hooks/useTouristicPlaces';

const Home: React.FC = () => {
  const [activeCard, setActiveCard] = useState(0);
  const [language, setLanguage] = useState<'en' | 'es'>('en');
  const touristicPlaces = useTouristicPlaces();

  const handleCardChange = (index: number) => {
    setActiveCard(index);
  };

  const handleLanguageChange = () => {
    setLanguage((prev) => (prev === 'en' ? 'es' : 'en'));
  };

  return (
    <div className="bg-[#FFF8E1] font-['Arial', 'sans-serif'] flex flex-col min-h-screen overflow-auto">
      <Header onLanguageChange={handleLanguageChange} />
      <div className="bg-[#D32F2F] h-[10px]"></div>
      <div className="bg-[#FBC02D] h-[10px]"></div>
      <div className="bg-[#388E3C] h-[10px]"></div>
      <main className="flex flex-grow overflow-auto">
        <div className="flex flex-col md:flex-row flex-1">
          <div className="flex flex-col items-center justify-center w-full md:w-1/2 p-8 relative">
            <div className="relative w-full flex overflow-hidden">
              <div
                className="flex transition-transform duration-500"
                style={{ transform: `translateX(-${activeCard * 100}%)` }}
              >
                {touristicPlaces.map((place, index) => (
                  <div
                    key={place.id}
                    className="flex-shrink-0 w-full h-full flex items-center justify-center"
                  >
                    <div className="shadow-lg">
                      <Card
                        title={language === 'en' ? place.engName : place.espName}
                        description={language === 'en' ? place.engDescription : place.espDescription}
                        imageSrc={place.image}
                      />
                    </div>
                  </div>
                ))}
              </div>
            </div>
            <div className="flex justify-center w-full mt-4">
              <CarouselButtons
                totalCards={touristicPlaces.length}
                activeCard={activeCard}
                onChange={handleCardChange}
              />
            </div>
          </div>
          <div className="flex items-center justify-center w-full md:w-1/2 p-8">
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


