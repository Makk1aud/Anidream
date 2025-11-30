import React, { useState, useEffect } from "react";
import SectionTitle from "../../UI/title/SectionTitle";
import AnimeCard from "./AnimeCard/MediaCard";
import cl from "./Catalog.module.css";
import FilterBar from "./FilterBar/FilterBar";
import { fetchAnimeList } from "../../../api/mediaAPI";

export default function Catalog({ ref, id }) {
  const [cards, setCards] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadAnimeList = async () => {
      try {
        setIsLoading(true);
        setError(null);

        const response = await fetchAnimeList();

        const animeData = response || [];

        const animeCards = animeData.map(anime => ({
          id: anime.mediaId,
          imagePath: "assets/tyler-derden.jpg",
          grade: anime.rating,
          title: anime.title,
          subTitle: anime.alias
        }))

        setCards(animeCards);
      } catch (err) {
        console.log("Fetching anime error: ", err);
        setError("Fetching anime error");
      } finally {
        setIsLoading(false);
      }
    };

    loadAnimeList();
  }, []);

  return (
    <div className={cl.conatainer} ref={ref} id={id}>
      <FilterBar />
      <div className={cl.catalog}>
        {cards.map((card) => {
          return <AnimeCard card={card} key={card.id} />;
        })}
      </div>
    </div>
  );
}
