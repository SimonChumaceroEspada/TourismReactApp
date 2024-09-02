import React from "react";
import { useLocation } from "react-router-dom";
import { useLanguage } from "../../context/LanguageContext";

const Header: React.FC = () => {
  const location = useLocation();
  const isHome = location.pathname === "/";
  const { language, setLanguage } = useLanguage();

  const toggleLanguage = () => {
    setLanguage(language === "en" ? "es" : "en");
  };

  const departamentos = ["Chuquisaca", "Cochabamba", "La Paz", "Oruro", "Pando", "Potosí", "Santa Cruz", "Tarija", "Beni"];

  return (
    <header className="bg-[#FFF8E1] py-4 px-8 border-b border-[#B65172]">
      <nav className="flex flex-col md:flex-row md:items-center md:justify-between">
        <div className="flex flex-col md:flex-row md:flex-grow md:items-center justify-between">
          <ul className="flex flex-wrap justify-center space-x-4 md:space-x-8">
            <li>
              <a
                href="/"
                className={`text-[#333333] hover:text-[#B65172] ${
                  isHome ? "text-[#B65172]" : ""
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
              onClick={toggleLanguage}
              className="bg-[#209674] text-white w-8 h-8 flex items-center justify-center rounded-full hover:bg-[#1E8E7E]"
            >
              {language === "en" ? "EN" : "ES"}
            </button>
          </div>
        </div>
      </nav>
    </header>
  );
};

export default Header;
