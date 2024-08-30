import React, { useState } from 'react';
import { motion, AnimatePresence } from 'framer-motion';
import Header from '../components/Header/Header';
import Flag from '../components/Flag/Flag';
import Tabs from '../components/Tabs/Tabs';
import ArrowButton from '../components/ButtonsDepartament/ButtonsDepartament';
import CardDepartament from '../components/CardDepartament/CardDepartament';

const images = [
  { src: '/image1.jpg', alt: 'Castle of Gloriet' },
  { src: 'image1.jpg', alt: 'Interior' },
  { src: '/image2.jpg', alt: 'Courtyard' },
];

type TabName = 'Places' | 'Traditional Food' | 'Events Calendar';

const descriptions: Record<TabName, string> = {
  Places: 'A whimsical castle near Sucre, Bolivia, built by self-proclaimed royalty. Its eclectic architecture and rich history make it a must-see.',
  'Traditional Food': 'Discover the local delicacies and traditional dishes unique to Sucre and Bolivia.',
  'Events Calendar': 'Stay updated with upcoming events and festivals in Sucre and the surrounding areas.',
};

const Chuquisaca: React.FC = () => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [activeTab, setActiveTab] = useState<TabName>('Places');

  const handlePrev = () => {
    setCurrentIndex((prevIndex) => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
  };

  const handleNext = () => {
    setCurrentIndex((prevIndex) => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
  };

  const reorderedImages = [
    images[(currentIndex + 0) % images.length],
    images[(currentIndex + 1) % images.length],
    images[(currentIndex + 2) % images.length],
  ];

  return (
    <div className="bg-[#FFF8E1] font-sans min-h-screen flex flex-col">
      <Header onLanguageChange={() => {}} />
      <Flag />
      <main className="flex-1 flex flex-col p-4 md:p-6 max-w-6xl mx-auto w-full">
        <Tabs onTabChange={setActiveTab} />
        <div className="flex flex-col lg:flex-row justify-between items-start gap-6 lg:gap-12 min-h-[calc(100vh-300px)]">
          <div className="w-full lg:w-1/4 mb-6 lg:mb-0">
            {/* Display description based on active tab */}
            <h2 className="text-3xl font-semibold text-[#B65172] mb-4">{activeTab}</h2>
            <p className="text-[#333333] text-sm">{descriptions[activeTab]}</p>
          </div>
          <div className="w-full lg:w-3/4 flex flex-col items-center">
            {/* Navigation buttons for mobile and tablet */}
            <div className="flex justify-center space-x-4 mb-4 lg:hidden w-full">
              <ArrowButton direction="left" onClick={handlePrev} />
              <ArrowButton direction="right" onClick={handleNext} />
            </div>
            <div className="flex flex-wrap lg:flex-nowrap justify-center lg:justify-between items-center w-full gap-4 lg:gap-8">
              <AnimatePresence initial={false}>
                {reorderedImages.map((image, index) => (
                  <motion.div
                    key={image.src}
                    layout
                    initial={{ scale: 0.8, opacity: 0 }}
                    animate={{ 
                      scale: 1, 
                      opacity: 1,
                      y: index === 1 ? 0 : 0 
                    }}
                    exit={{ scale: 0.8, opacity: 0 }}
                    transition={{ duration: 0.3 }}
                    className="flex-shrink-0 flex-grow-0"
                  >
                    <CardDepartament
                      image={image.src}
                      alt={image.alt}
                      size={index === 0 ? 'large' : 'small'}
                    />
                  </motion.div>
                ))}
              </AnimatePresence>
            </div>
            {/* Navigation buttons for desktop */}
            <div className="hidden lg:flex justify-center space-x-4 mt-4 w-full">
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
