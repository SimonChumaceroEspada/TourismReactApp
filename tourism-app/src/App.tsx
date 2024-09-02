import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Chuquisaca from './pages/Chuquisaca';
import { LanguageProvider } from './context/LanguageContext';
import './index.css';
import SantaCruz from './pages/SantaCruz';

function App() {
  return (
    <LanguageProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/chuquisaca" element={<Chuquisaca />} />
          <Route path="/santa cruz" element={<SantaCruz />} />
        </Routes>
      </BrowserRouter>
    </LanguageProvider>
  );
}

export default App;