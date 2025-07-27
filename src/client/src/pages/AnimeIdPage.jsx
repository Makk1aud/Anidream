import React, { use } from "react";
import { useParams } from "react-router-dom";
import cl from "./AnimeIdPage.module.css";
import AnimePageTitle from "../components/UI/title/AnimePageTitle";
import { animeList } from "../data/animeList.js";

export default function AnimeIdPage() {
  const params = useParams();
  const anime = animeList.find((item) => item.id === Number(params.id));

  return (
    <div className={cl.anime__page}>
      <img className={cl.anime__img} src={anime.imagePath} />
      <AnimePageTitle title={anime.title} subtitle={anime.subtitle} />
    </div>
  );
}
