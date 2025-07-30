import React, { use } from "react";
import { useParams } from "react-router-dom";
import cl from "./AnimePage.module.css";
import AnimePageTitle from "../components/UI/title/AnimePageTitle.jsx";
import { animeList } from "../data/animeList.js";
import Header from "../components/UI/navbar/Header.jsx";

export default function AnimePage(props) {
  const params = useParams();
  const anime = animeList.find((item) => item.id === Number(params.id));

  return (
    <div>
      <Header />
      <div
        className={cl.anime__page__container}
        style={{
          "--bg-image": `url(${anime.imagePath})`,
        }}
      >
        <div className={cl.anime__page}>
          <img className={cl.anime__img} src={anime.imagePath} />
          <AnimePageTitle title={anime.title} subtitle={anime.subtitle} />
        </div>
      </div>
    </div>
  );
}
