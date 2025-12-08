import React, { useState } from "react";
import { useParams } from "react-router-dom";
import MediaGenre from "./MediaGenre";
import cl from "./MediaInfo.module.css";

export default function MediaDescription({ media }) {
  const genres = media?.genres || [];

  const monthNames = [
    "Января",
    "Февраля",
    "Марта",
    "Апреля",
    "Мая",
    "Июня",
    "Июля",
    "Августа",
    "Сентября",
    "Октября",
    "Ноября",
    "Декабря",
  ];

  function getMonthName(date) {
    const dateObj = new Date(date);
    const monthIndex = dateObj.getMonth();
    return monthNames[monthIndex];
  }

  return (
    <div className={cl.media__description}>
      <div className={cl.genres}>
        <p>Жанры:&nbsp;&nbsp;</p>
        {genres.map((genre) => (
          <MediaGenre genre={genre} />
        ))}
      </div>
      <ul className={cl.media__details}>
        <li>Год производства: {new Date(media.releaseDate).getFullYear()}</li>
        <li>
          Дата премьеры: {new Date(media.releaseDate).getDate()}{" "}
          {getMonthName(media.releaseDate)}{" "}
          {new Date(media.releaseDate).getFullYear()}
        </li>
        <li>
          Серии: {media.currentEpisodes} / {media.totalEpisodes}
        </li>
        <li>Студия: {media.studio.title}</li>
        <li>Режисcер: {media.director.fullName}</li>
        <li>
          <div className={cl.rating}>
            Рейтинг: {media.rating}
            <img src="/assets/grade.svg"/>
          </div>
        </li>
      </ul>
    </div>
  );
}
