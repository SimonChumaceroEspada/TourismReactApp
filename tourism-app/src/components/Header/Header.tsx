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
          <div className="mt-4 md:mt-0 flex justify-center md:justify-end space-x-4">
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
