import React, { useState } from "react";
import MediaGenre from "./MediaGenre";
import cl from "./MediaInfo.module.css";

export default function MediaDescription() {
  const [genres, setGenres] = useState([
    {
      id: "romance",
      title: "Романтика",
      imgPath: "/genres/romance.svg",
    },
    {
      id: "drama",
      title: "Драма",
      imgPath: "/genres/drama.png",
    },
    {
      id: "adventure",
      title: "Приключения",
      imgPath: "/genres/adventure.png",
    },
    {
      id: "fantsy",
      title: "Фэнтези",
      imgPath: "/genres/fantasy.png",
    },
    {
      id: "sword",
      title: "Сражения на мечах",
      imgPath: "/genres/sword.png",
    },
  ]);

  return (
    <div className={cl.Media__description}>
      <div className={cl.genres}>
        <p>Жанры:&nbsp;&nbsp;</p>
        {genres.map((genre) => (
          <MediaGenre genre={genre} />
        ))}
      </div>
      <ul className={cl.Media__details}>
        <li>Эпизоды:</li>
        <li>Год:</li>
        <li>Дата премьеры:</li>
        <li>Статус:</li>
        <li>Тип:</li>
        <li>Возрастное ограничение:</li>
      </ul>
    </div>
  );
}
