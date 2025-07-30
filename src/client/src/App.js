import "./App.css";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import Home from "./pages/Home";
import AnimePage from "./pages/AnimePage";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to='/home' replace /> } />
        <Route path="/home" element={<Home />} />
        <Route path="/anime/:id" element={<AnimePage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App; 
