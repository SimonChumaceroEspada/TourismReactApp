import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import './index.css'; // Importa el archivo CSS global

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} /> 
        {/* Agrega más rutas para otras páginas si es necesario */}
      </Routes>
    </BrowserRouter>
  );
}

export default App;