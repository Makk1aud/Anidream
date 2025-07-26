import React from "react";
import cl from "./AnimeCard.module.css";
import AnimeCardTitle from "./UI/title/AnimeCardTitle";

export default function AnimeCard(props) {
  return (
    <div
      className={cl.card}
      style={{
        backgroundImage: `linear-gradient(rgba(0,0,0,0.4), rgba(0,0,0,0.4)), url(${props.imagePath})`
      }}
    >
      <AnimeCardTitle title="Jujutsu Kaisen" />
    </div>
  );
}
