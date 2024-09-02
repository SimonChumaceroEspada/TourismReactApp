import React from 'react';
import { useLanguage } from "../../context/LanguageContext";

// Cambiar los nombres de las pestañas
type TabName = 'Tourist Sites' | 'Traditional Food' | 'Traditional Celebrations';

interface TabsProps {
  onTabChange: (tab: TabName) => void;
}

const Tabs: React.FC<TabsProps> = ({ onTabChange }) => {
  const [activeTab, setActiveTab] = React.useState<TabName>('Tourist Sites');
  const { language } = useLanguage();

  const translateTabName = (tabName: TabName) => {
    switch (tabName) {
      case "Tourist Sites":
        return language === "en" ? "Tourist Sites" : "Lugares Turísticos";
      case "Traditional Food":
        return language === "en" ? "Traditional Food" : "Comida Tradicional";
      case "Traditional Celebrations":
        return language === "en" ? "Traditional Celebrations" : "Fiestas Típicas";
      default:
        return tabName;
    }
  };

  const tabs: TabName[] = ['Tourist Sites', 'Traditional Food', 'Traditional Celebrations'];

  return (
    <div className="flex flex-col md:flex-row md:justify-between items-center px-4 md:px-6 w-full">
      {tabs.map((tab) => (
        <button
          key={tab}
          onClick={() => {
            setActiveTab(tab);
            onTabChange(tab);
          }}
          className="relative flex-1 flex flex-col items-center py-4 md:py-8"
        >
          <span
            className={`text-lg md:text-xl font-bold ${activeTab === tab ? 'text-red-500' : 'text-gray-400'} mb-4 md:mb-8`}
          >
            {translateTabName(tab)}
          </span>
          <div className="relative flex flex-col items-center w-full">
            <div
              className={`w-full h-0.5 ${activeTab === tab ? 'bg-red-500' : 'bg-gray-200'}`}
              style={{ marginBottom: '6px' }}
            />
            <div
              className={`absolute w-6 h-6 rounded-full ${activeTab === tab ? 'bg-red-500' : 'bg-gray-200'}`}
              style={{ top: '-12px' }}
            />
          </div>
        </button>
      ))}
    </div>
  );
};

export default Tabs;
