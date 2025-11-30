import { useParams } from "react-router-dom";
import cl from "./MediaPage.module.css";
import MediaPageTitle from "../components/MediaPage/MediaPageTitle.jsx";
import { MediaList } from "../data/MediaList.js";
import Header from "../components/UI/navbar/Header.jsx";
import MediaInfo from "../components/MediaPage/MediaInfo.jsx";
import MediaDescription from "../components/MediaPage/MediaDescription.jsx";
import Player from "../components/MediaPage/Player.jsx";
import { useRef } from "react";
import Footer from "../components/UI/footer/Footer.jsx";
import { useScroll } from "../hooks/useScroll.js";
import { fetchMediaList } from "../api/mediaAPI.js";

export default function MediaPage(props) {

  const params = useParams();
  const Media = MediaList.find((item) => item.id === Number(params.id));

  const [playerRef, scrollToPlayer] = useScroll();

  return (
    <div>
      <Header />
      <div
        className={cl.Media__page__container}
        style={{
          "--bg-image": `url(${Media.imagePath})`,
        }}
      >
        <div className={cl.Media__page}>
          <div className={cl.main__info}>
            <div className={cl.Media__img__container} onClick={scrollToPlayer}>
              <img className={cl.Media__img} src={Media.imagePath} />
              <div className={cl.go__to__view}>
                <img
                  className={cl.go__to__view__img}
                  src="/assets/play.svg"
                  alt="play"
                />
                <h2 className={cl.go__to__view__text}>Смотреть</h2>
              </div>
            </div>
            <div className={cl.Media__info}>
              <MediaPageTitle title={Media.title} subtitle={Media.subtitle} />
              <MediaInfo />
            </div>
          </div>
          <MediaDescription />
          <div className={cl.player__container} ref={playerRef}>
            <Player url={Media.url} title={Media.subtitle} />
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
}
