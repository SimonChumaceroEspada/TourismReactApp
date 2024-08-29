import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Chuquisaca from './pages/Chuquisaca'; // Asegúrate de que el nombre y la ruta sean correctos
import './index.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} /> 
        <Route path="/chuquisaca" element={<Chuquisaca />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
