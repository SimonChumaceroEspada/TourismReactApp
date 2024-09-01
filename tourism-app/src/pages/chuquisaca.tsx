import React, { useState } from "react";
import { motion, AnimatePresence } from "framer-motion";
import Header from "../components/Header/Header";
import Flag from "../components/Flag/Flag";
import Tabs from "../components/Tabs/Tabs";
import ArrowButton from "../components/ButtonsDepartament/ButtonsDepartament";
import CardDepartament from "../components/CardDepartament/CardDepartament";
import usePlacesDataForChuquisaca from "../hooks/usePlacesDataForChuquisaca";
import { useLanguage } from "../context/LanguageContext";

type TabName = "Places" | "Traditional Food" | "Events Calendar";

const Chuquisaca: React.FC = () => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [activeTab, setActiveTab] = useState<TabName>("Places");
  const { foodsData, touristicPlacesData, partiesData } =
    usePlacesDataForChuquisaca();
  const { language, setLanguage } = useLanguage();
  const handleLanguageChange = () => {
    setLanguage((prev) => (prev === "en" ? "es" : "en"));
  };

  console.log("foodsData", foodsData);
  console.log("touristicPlacesData", touristicPlacesData);
  console.log("partiesData", partiesData);

  // Function to get the appropriate data based on the active tab
  const getDataForActiveTab = () => {
    if (activeTab === "Places") {
      return touristicPlacesData;
    } else if (activeTab === "Traditional Food") {
      return foodsData;
    } else if (activeTab === "Events Calendar") {
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
      <Header onLanguageChange={handleLanguageChange} />
      <Flag />
      <main className="flex-1 flex flex-col p-4 md:p-6 max-w-6xl mx-auto w-full">
        <Tabs onTabChange={setActiveTab} />
        <div className="flex flex-col lg:flex-row justify-between items-start gap-6 lg:gap-12 min-h-[calc(100vh-300px)]">
          <div className="w-full lg:w-1/4 mb-6 lg:mb-0 text-center">
            <h2 className="text-3xl font-semibold text-[#B65172] mb-4">
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
            {/* Navigation buttons for mobile and tablet */}
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
