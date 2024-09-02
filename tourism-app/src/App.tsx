import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Chuquisaca from "./pages/Chuquisaca";
import { LanguageProvider } from "./context/LanguageContext";
import "./index.css";
import SantaCruz from "./pages/SantaCruz";
import LaPaz from "./pages/LaPaz";
import Cochabamba from "./pages/Cochabamba";
import Oruro from "./pages/Oruro";
import Potosi from "./pages/Potosi";
import Tarija from "./pages/Tarija";
import Beni from "./pages/Beni";
import Pando from "./pages/Pando";

function App() {
  return (
    <LanguageProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/chuquisaca" element={<Chuquisaca />} />
          <Route path="/santa cruz" element={<SantaCruz />} />
          <Route path="/la paz" element={<LaPaz />} />
          <Route path="/cochabamba" element={<Cochabamba />} />
          <Route path="/oruro" element={<Oruro />} />
          <Route path="/potosí" element={<Potosi />} />
          <Route path="/tarija" element={<Tarija />} />
          <Route path="/beni" element={<Beni />} />
          <Route path="/pando" element={<Pando />} />
        </Routes>
      </BrowserRouter>
    </LanguageProvider>
  );
}

export default App;
