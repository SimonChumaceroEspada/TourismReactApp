import React, { useState } from 'react';

const Tabs: React.FC = () => {
  const [activeTab, setActiveTab] = useState('Places');

  const tabs = [
    { name: 'Places', color: 'bg-red-500' },
    { name: 'Traditional Food', color: 'bg-yellow-500' },
    { name: 'Events calendar', color: 'bg-green-500' }
  ];

  return (
    <div className="flex flex-col md:flex-row md:justify-between items-center px-4 md:px-6 w-full">
      {tabs.map((tab) => (
        <button
          key={tab.name}
          onClick={() => setActiveTab(tab.name)}
          className="relative flex-1 flex flex-col items-center py-4 md:py-8"
        >
          <span
            className={`text-lg md:text-xl font-bold ${activeTab === tab.name ? tab.color.replace('bg-', 'text-') : 'text-gray-700'} mb-4 md:mb-8`}
          >
            {tab.name}
          </span>
          <div className="relative flex flex-col items-center w-full">
            <div
              className={`w-full h-0.5 ${activeTab === tab.name ? tab.color : 'bg-gray-200'}`}
              style={{ marginBottom: '6px' }}
            />
            <div
              className={`absolute w-6 h-6 rounded-full ${activeTab === tab.name ? tab.color : 'bg-gray-200'}`}
              style={{ top: '-12px' }}
            />
          </div>
        </button>
      ))}
    </div>
  );
};

export default Tabs;

