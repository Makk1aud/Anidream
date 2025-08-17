import React from "react";
import cl from "./AnimeCard.module.css";
import AnimeCardTitle from "./titles/AnimeCardTitle";
import AnimeCardSubTitle from "./titles/AnimeCardSubTitle";
import { useNavigate } from "react-router-dom";

export default function AnimeCard(props) {
  const router = useNavigate();
  console.log(router);

  return (
    <div
      className={cl.card}
      style={{
        "--bg-image": `url(${props.card.imagePath})`,
      }}
      onClick={() => router(`/anime/${props.card.id}`)}
    >
      <div className={cl.grade}>
        <div className={cl.grade__container}>
          <p>{props.card.grade}</p>
          <img src="assets/grade.svg" />
        </div>
      </div>

      <div className={cl.titles__container}>
        <AnimeCardTitle title={props.card.title} />
        <AnimeCardSubTitle title={props.card.subtitle} />
      </div>
    </div>
  );
}
