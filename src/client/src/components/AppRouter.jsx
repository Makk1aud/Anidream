import React from "react";
import { BrowserRouter, Navigate, Route, Routes } from "react-router-dom";
import Home from "../pages/Home";
import MediaPage from "../pages/MediaPage";
import AdminPanel from "./AdminPanel/AdminPanel"
import MediaPanel from "./AdminPanel/Panels/MediaPanel";
import GenrePanel from "./AdminPanel/Panels/GenrePanel"
import StudioPanel from "./AdminPanel/Panels/StudioPanel"
import DirectorPanel from "./AdminPanel/Panels/DirectorPanel";

export default function AppRouter() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to="/home" replace />} />
        <Route path="/home" element={<Home />} />
        <Route path="/Media/:id" element={<MediaPage />} />

        <Route path="/admin" element={<AdminPanel />}>
          <Route index element={<Navigate to="media" replace />} />
          <Route path="media" element={<MediaPanel />} />
          <Route path="genres" element={<GenrePanel />} />
          <Route path="studios" element={<StudioPanel />} />
          <Route path="directors" element={<DirectorPanel />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
