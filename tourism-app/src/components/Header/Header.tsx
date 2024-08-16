import React from 'react';

const departamentos = [
  'Chuquisaca',
  'Cochabamba',
  'Tarija',
  'La Paz',
  'Santa Cruz',
  'Potosí',
  'Oruro',
  'Pando',
  'Beni',
];

interface HeaderProps {
  onLanguageChange: () => void; // Función para cambiar el idioma
}

const Header: React.FC<HeaderProps> = ({ onLanguageChange }) => {
  return (
    <header className="bg-[#FFF8E1] py-4 px-8 flex items-center justify-between border-b border-[#B65172]">
      <nav className="flex flex-grow items-center">
        <ul className="flex space-x-8 flex-grow">
          <li>
            <a href="/" className="text-[#333333] hover:text-[#B65172]">
              Home
            </a>
          </li>
          {departamentos.map((departamento) => (
            <li key={departamento}>
              <a
                href={`/${departamento.toLowerCase()}`} 
                className="text-[#333333] hover:text-[#B65172]"
              >
                {departamento}
              </a>
            </li>
          ))}
        </ul>
        <div className="relative flex-grow flex justify-center">
          <input
            type="search"
            className="bg-[#EEEEEE] rounded-lg py-2 pl-10 pr-4 focus:outline-none w-full max-w-sm"
            placeholder="Search..."
          />
          <span className="absolute inset-y-0 left-3 flex items-center pl-3 pointer-events-none">
            <svg
              className="h-5 w-5 text-[#B65172]" 
              fill="currentColor"
              viewBox="0 0 20 20"
            >
              {/* Ícono de búsqueda */}
              <path
                fillRule="evenodd"
                d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.537 4.536a1 1 0 01-1.414 1.414l-4.536-4.537A6 6 0 012 8z"
                clipRule="evenodd"
              />
            </svg>
          </span>
        </div>
        <div className="flex items-center space-x-4">
          <button className="bg-[#FFE051] text-white w-8 h-8 flex items-center justify-center rounded-full hover:bg-[#F5E300]">
          </button>
          <button 
            onClick={onLanguageChange}
            className="bg-[#209674] text-white w-8 h-8 flex items-center justify-center rounded-full hover:bg-[#1E8E7E]"
          >
            🌐
          </button>
        </div>
      </nav>
    </header>
  );
};

export default Header;
