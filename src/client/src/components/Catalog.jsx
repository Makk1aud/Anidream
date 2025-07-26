import React, {useState} from "react";
import SectionTitle from "./UI/title/SectionTitle";
import AnimeCard from "./AnimeCard/AnimeCard";
import cl from "./Catalog.module.css";

export default function Catalog() {
  const [cards, setCards] = useState([
    {imagePath: "/anime-previews/magic-fight.webp", grade: '4.8', title: 'Jujutsu Kaisen', subtitle: 'Магическая битва'},
    {imagePath: "/anime-previews/demon-slayer.jpeg", grade: '4.9', title: 'Demon Slayer', subtitle: 'Клинок рассекающий демонов'},
    {imagePath: "/anime-previews/one-piece.jpg", grade: '4.7', title: 'One piece', subtitle: 'Ван-пис'},
    {imagePath: "/anime-previews/naruto.jpg", grade: '4.6', title: 'Naruto', subtitle: 'Наруто'},
    {imagePath: "/anime-previews/tokyo-ghoul.jpg", grade: '4.9', title: 'Tokyo Ghoul', subtitle: 'Токийский гуль'}
  ]);

  return (
    <div className={cl.conatainer}>
      <div className={cl.catalog}>
        {cards.map((card) => {
          return <AnimeCard card={card} />
        })}
      </div>
    </div>
  );
}
