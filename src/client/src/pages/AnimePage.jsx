import { useParams } from "react-router-dom";
import cl from "./AnimePage.module.css";
import AnimePageTitle from "../components/AnimePage/AnimePageTitle.jsx";
import { animeList } from "../data/animeList.js";
import Header from "../components/UI/navbar/Header.jsx";
import AnimeInfo from "../components/AnimePage/AnimeInfo.jsx";
import AnimeDescription from "../components/AnimePage/AnimeDescription.jsx";

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
          <div className={cl.main__info}>
            <img className={cl.anime__img} src={anime.imagePath} />
            <div className={cl.anime__info}>
              <AnimePageTitle title={anime.title} subtitle={anime.subtitle} />
              <AnimeInfo />
            </div>
          </div>
          <AnimeDescription />
        </div>
      </div>
    </div>
  );
}
