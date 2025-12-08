import React, { useState, useEffect } from "react";
import SectionTitle from "../../UI/title/SectionTitle";
import MediaCard from "./MediaCard/MediaCard";
import cl from "./Catalog.module.css";
import FilterBar from "./FilterBar/FilterBar";
import { fetchMediaList, fetchMediaImage } from "../../../api/mediaAPI";

export default function Catalog({ ref, id }) {
  const [cards, setCards] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    const loadMediaList = async () => {
      try {
        setIsLoading(true);
        setError(null);

        const response = await fetchMediaList();

        const mediaData = response || [];

        const MediaCards = mediaData.map(media => ({
          id: media.mediaId,
          alias: media.alias,
          subTitle: media.subtitle,
          imagePath: media.hasImage === 1
            ? fetchMediaImage(media.alias)
            : "assets/no-image.png", 
          grade: media.rating,
          title: media.title,
        }))
        
        console.log("MediaCards: ", MediaCards);
        setCards(MediaCards);
      } catch (err) {
        console.log("Fetching meida error: ", err);
        setError("Fetching media error");
      } finally {
        setIsLoading(false);
      }
    };

    loadMediaList();
  }, []);

  return (
    <div className={cl.conatainer} ref={ref} id={id}>
      <FilterBar />
      <div className={cl.catalog}>
        {cards.map((card) => {
          return <MediaCard card={card} key={card.id} />;
        })}
      </div>
    </div>
  );
}
