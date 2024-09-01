import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Chuquisaca from './pages/Chuquisaca';
import { LanguageProvider } from './context/LanguageContext';
import './index.css';

function App() {
  return (
    <LanguageProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/chuquisaca" element={<Chuquisaca />} />
        </Routes>
      </BrowserRouter>
    </LanguageProvider>
  );
}

export default App;