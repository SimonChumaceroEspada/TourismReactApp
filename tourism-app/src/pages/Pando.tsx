import React, { useState } from "react";
import { motion, AnimatePresence } from "framer-motion";
import Header from "../components/Header/Header";
import Flag from "../components/Flag/Flag";
import Tabs from "../components/Tabs/Tabs";
import ArrowButton from "../components/ButtonsDepartament/ButtonsDepartament";
import CardDepartament from "../components/CardDepartament/CardDepartament";
import usePlacesData from "../hooks/usePlacesData";
import { useLanguage } from "../context/LanguageContext";

// Cambiar los nombres de las pestañas
type TabName = "Tourist Sites" | "Traditional Food" | "Traditional Celebrations";

const Pando: React.FC = () => {
  const placesId = 10;
  const [currentIndex, setCurrentIndex] = useState(0);
  const [activeTab, setActiveTab] = useState<TabName>("Tourist Sites");
  const { foodsData, touristicPlacesData, partiesData } = usePlacesData(placesId);
  const { language } = useLanguage();

  const getDataForActiveTab = () => {
    if (activeTab === "Tourist Sites") {
      return touristicPlacesData;
    } else if (activeTab === "Traditional Food") {
      return foodsData;
    } else if (activeTab === "Traditional Celebrations") {
      return partiesData;
    }
    return [];
  };

  const dataForActiveTab = getDataForActiveTab();

  const handlePrev = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === 0 ? dataForActiveTab.length - 1 : prevIndex - 1
    );
  };

  const handleNext = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === dataForActiveTab.length - 1 ? 0 : prevIndex + 1
    );
  };

  if (dataForActiveTab.length === 0) {
    return <div></div>;
  }

  const reorderedItems = [
    dataForActiveTab[(currentIndex + 0) % dataForActiveTab.length],
    dataForActiveTab[(currentIndex + 1) % dataForActiveTab.length],
    dataForActiveTab[(currentIndex + 2) % dataForActiveTab.length],
  ];

  return (
    <div className="bg-[#FFF8E1] font-sans min-h-screen flex flex-col">
      <Header />
      <Flag />
      <main className="flex-1 flex flex-col p-4 md:p-6 max-w-6xl mx-auto w-full">
        <Tabs onTabChange={setActiveTab} />
        <div className="flex flex-col lg:flex-row justify-between items-start gap-6 lg:gap-12 min-h-[calc(100vh-300px)]">
          <div className="w-full lg:w-1/4 mb-6 lg:mb-0">
            <h2 className="text-3xl font-semibold text-[#B65172] mb-4 text-center">
              {language === "en"
                ? dataForActiveTab[currentIndex]?.engName
                : dataForActiveTab[currentIndex]?.espName}
            </h2>
            <p className="text-[#333333] text-sm">
              {language === "en"
                ? dataForActiveTab[currentIndex]?.engDescription
                : dataForActiveTab[currentIndex]?.espDescription}
            </p>
          </div>
          <div className="w-full lg:w-3/4 flex flex-col items-center">
            <div className="flex justify-center space-x-4 mb-4 lg:hidden w-full">
              <ArrowButton direction="left" onClick={handlePrev} />
              <ArrowButton direction="right" onClick={handleNext} />
            </div>
            <div className="flex flex-wrap lg:flex-nowrap justify-center lg:justify-between items-center w-full gap-4 lg:gap-8 bd-2">
              <AnimatePresence initial={false}>
                {reorderedItems.map((item, index) => (
                  <motion.div
                    key={item.id}
                    layout
                    initial={{ scale: 0.8, opacity: 0 }}
                    animate={{
                      scale: 1,
                      opacity: 1,
                      y: index === 1 ? 0 : 0,
                    }}
                    exit={{ scale: 0.8, opacity: 0 }}
                    transition={{ duration: 0.3 }}
                    className="flex-shrink-0 flex-grow-0"
                  >
                    <CardDepartament
                      image={item.image}
                      alt={item.espName}
                      size={index === 0 ? "large" : "small"}
                    />
                  </motion.div>
                ))}
              </AnimatePresence>
            </div>
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

export default Pando;
