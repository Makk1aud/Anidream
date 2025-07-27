import React, {useState} from "react";
import SectionTitle from "./UI/title/SectionTitle";
import AnimeCard from "./AnimeCard/AnimeCard";
import cl from "./Catalog.module.css";

export default function Catalog() {
  const [cards, setCards] = useState([
    {id: 1, imagePath: "/anime-previews/magic-fight.webp", grade: '4.8', title: 'Jujutsu Kaisen', subtitle: 'Магическая битва'},
    {id: 2, imagePath: "/anime-previews/demon-slayer.jpeg", grade: '4.9', title: 'Demon Slayer', subtitle: 'Клинок рассекающий демонов'},
    {id: 3, imagePath: "/anime-previews/one-piece.jpg", grade: '4.7', title: 'One piece', subtitle: 'Ван-пис'},
    {id: 4, imagePath: "/anime-previews/naruto.jpg", grade: '4.6', title: 'Naruto', subtitle: 'Наруто'},
    {id: 5, imagePath: "/anime-previews/tokyo-ghoul.jpg", grade: '4.9', title: 'Tokyo Ghoul', subtitle: 'Токийский гуль'}
  ]);

  return (
    <div className={cl.conatainer}>
      <div className={cl.catalog}>
        {cards.map((card) => {
          return <AnimeCard card={card} key={card.id}/>
        })}
      </div>
    </div>
  );
}
