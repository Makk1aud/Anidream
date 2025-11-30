import React from "react";
import cl from "./MediaCard.module.css";
import MediaCardTitle from "./titles/MediaCardTitle";
import MediaCardSubTitle from "./titles/MediaCardSubTitle";
import { useNavigate } from "react-router-dom";

export default function MediaCard(props) {
  const router = useNavigate();
  console.log(router);

  return (
    <div
      className={cl.card}
      style={{
        "--bg-image": `url(${props.card.imagePath})`,
      }}
      onClick={() => router(`/Media/${props.card.mediaId}`)}
    >
      <div className={cl.grade}>
        <div className={cl.grade__container}>
          <p>{props.card.grade}</p>
          <img src="assets/grade.svg" />
        </div>
      </div>

      <div className={cl.titles__container}>
        <MediaCardTitle title={props.card.title} />
        <MediaCardSubTitle title={props.card.subtitle} />
      </div>
    </div>
  );
}
