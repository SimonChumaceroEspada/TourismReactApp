import React, { useState, useEffect } from "react";
import Header from "../components/Header/Header";
import Card from "../components/Card/Card";
import CarouselButtons from "../components/CarrouselButtons/CarrouselButtons";
import useTouristicPlacesById from "../hooks/useTouristicPlacesById";
import Flag from "../components/Flag/Flag";
import Button from "../components/Button/Button";
import { useLanguage } from "../context/LanguageContext";

const Home: React.FC = () => {
  const [activeCard, setActiveCard] = useState(0);
  const touristicPlaces = useTouristicPlacesById();
  const { language } = useLanguage();

  useEffect(() => {
    const interval = setInterval(() => {
      setActiveCard((prevCard) =>
        prevCard === touristicPlaces.length - 1 ? 0 : prevCard + 1
      );
    }, 3000);

    return () => clearInterval(interval); 
  }, [touristicPlaces.length]);

  const handleCardChange = (index: number) => {
    setActiveCard(index);
  };

  return (
    <div className="bg-[#FFF8E1] font-['Arial', 'sans-serif'] min-h-screen flex flex-col">
      <Header />
      <Flag />
      <main className="flex-1 flex flex-col overflow-y-auto p-8">
        <div className="flex flex-col md:flex-row w-full">
          <div className="flex flex-col items-center justify-center w-full md:w-1/2">
            <div className="relative w-full overflow-hidden">
              <div
                className="flex transition-transform duration-500"
                style={{ transform: `translateX(-${activeCard * 100}%)` }}
              >
                {touristicPlaces.map((place) => (
                  <div
                    key={place.id}
                    className="flex-shrink-0 w-full h-auto flex items-center justify-center px-4 md:px-6"                    
                  >
                    <Card
                      title={language === "en" ? place.engName : place.espName}
                      description={
                        language === "en"
                          ? place.engDescription
                          : place.espDescription
                      }
                      imageSrc={place.image}
                    />
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
          <div className="flex items-center justify-center w-full md:w-1/2 mt-8 md:mt-0">
            <Button onClick={() => alert("Explore More about Bolivia")}>
              {	
              language === "en" ? "Explore More about Bolivia!" : "Explora más sobre Bolivia!"
              }
            </Button>
          </div>
        </div>
      </main>
    </div>
  );
};

export default Home;
