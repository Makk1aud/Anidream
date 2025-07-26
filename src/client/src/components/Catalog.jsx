import React from "react";
import SectionTitle from "./UI/title/SectionTitle";
import AnimeCard from "./AnimeCard";
import cl from "./Catalog.module.css";

export default function Catalog() {
  return (
    <div className={cl.conatainer}>
      <div className={cl.catalog}>
        <AnimeCard imagePath="/anime-previews/magic-fight.webp" />
      </div>
    </div>
  );
}
