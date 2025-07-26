import React from "react";
import cl from "./AnimeCard.module.css";
import AnimeCardTitle from "./UI/title/AnimeCardTitle";
import AnimeCardSubTitle from "./UI/title/AnimeCardSubTitle";

export default function AnimeCard(props) {
  return (
    <div
      className={cl.card}
      style={{
        backgroundImage: `linear-gradient(rgba(0,0,0,0.4), rgba(0,0,0,0.4)), url(${props.imagePath})`,
      }}
    >
      <div className={cl.titles__container}>
        <AnimeCardTitle title="Jujutsu Kaisen" />
        <AnimeCardSubTitle title="Магическая битва" />
      </div>
    </div>
  );
}
