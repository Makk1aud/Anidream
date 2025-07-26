import React from "react";
import cl from "./AnimeCard.module.css";
import AnimeCardTitle from "./titles/AnimeCardTitle";
import AnimeCardSubTitle from "./titles/AnimeCardSubTitle";

export default function AnimeCard(props) {
  return (
    <div
      className={cl.card}
      style={{
        backgroundImage: `linear-gradient(rgba(0,0,0,0.4), rgba(0,0,0,0.4)), url(${props.card.imagePath})`
      }}
    >
      <div className={cl.grade}>
        <div className={cl.grade__container}>
          <p>{props.card.grade}</p>
          <img src="assets/moon-star.png" />
        </div>
      </div>

      <div className={cl.titles__container}>
        <AnimeCardTitle title={props.card.title} />
        <AnimeCardSubTitle title={props.card.subtitle} />
      </div>
    </div>
  );
}
