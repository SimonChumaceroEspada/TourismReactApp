import React from 'react';
import { useLocation } from 'react-router-dom';

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
  const location = useLocation();
  const isHome = location.pathname === '/';

  return (
    <header className="bg-[#FFF8E1] py-4 px-8 border-b border-[#B65172]">
      <nav className="flex flex-col md:flex-row md:items-center md:justify-between">
        <div className="flex flex-col md:flex-row md:flex-grow md:items-center justify-between">
          <ul className="flex flex-wrap justify-center space-x-4 md:space-x-8">
            <li>
              <a
                href="/"
                className={`text-[#333333] hover:text-[#B65172] ${
                  isHome ? 'text-[#B65172]' : ''
                }`}
              >
                Home
              </a>
            </li>
            {departamentos.map((departamento) => (
              <li key={departamento}>
                <a
                  href={`/${departamento.toLowerCase()}`}
                  className="text-[#333333] hover:text-[#B65172] hover:underline"
                >
                  {departamento}
                </a>
              </li>
            ))}
          </ul>

          <div className="mt-4 md:mt-0 relative flex-grow flex justify-center order-2 md:order-none">
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
                <path
                  fillRule="evenodd"
                  d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.537 4.536a1 1 0 01-1.414 1.414l-4.536-4.537A6 6 0 012 8z"
                  clipRule="evenodd"
                />
              </svg>
            </span>
          </div>

          <div className="mt-4 md:mt-0 flex justify-center md:justify-end space-x-4">
            <button className="bg-[#FFE051] text-white w-8 h-8 flex items-center justify-center rounded-full hover:bg-[#F5E300]">
            </button>
            <button
              onClick={onLanguageChange}
              className="bg-[#209674] text-white w-8 h-8 flex items-center justify-center rounded-full hover:bg-[#1E8E7E]"
            >
              🌐
            </button>
          </div>
        </div>
      </nav>
    </header>
  );
};

export default Header;
