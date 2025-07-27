import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import AnimeIdPage from "./pages/AnimeIdPage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/home" element={<Home />} />
        <Route path="/anime/:id" element={<AnimeIdPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App; 
