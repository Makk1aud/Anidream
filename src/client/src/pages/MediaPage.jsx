import { useParams } from "react-router-dom";
import cl from "./MediaPage.module.css";
import MediaPageTitle from "../components/MediaPage/MediaOverview/MediaPageTitle.jsx";
import { MediaList } from "../data/MediaList.js";
import Header from "../components/UI/navbar/Header.jsx";
import MediaInfo from "../components/MediaPage/MediaOverview/MediaInfo.jsx";
import MediaDescription from "../components/MediaPage/MediaOverview/MediaDescription.jsx";
import Player from "../components/MediaPage/Player.jsx";
import { useState, useEffect, useRef } from "react";
import Footer from "../components/UI/footer/Footer.jsx";
import { useScroll } from "../hooks/useScroll.js";
import { fetchMediaById, fetchMediaList, fetchMediaImage, fetchSeriesByNum } from "../api/mediaAPI.js";

export default function MediaPage(props) {

  const params = useParams();
  const [media, setMedia] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [playerRef, scrollToPlayer] = useScroll();

  useEffect(() => {
    const loadMedia = async () => {
      try {

        setIsLoading(true);
        setError(null);

        const mediaData = await fetchMediaById(params.id);
        setMedia(mediaData);

      } catch (err) {
        console.log("Fetching media error: ", err);
      } finally {
        setIsLoading(false);
      }
    };
    loadMedia();
  }, [params.id]);

  if (isLoading) {
    return (
      <div>
        <Header />
        <div>Загрузка...</div>
        <Footer />
      </div>
    );
  }

  if (error || !media) {
    return (
      <div>
        <Header />
        <div>{error || "Медиа не найдено"}</div>
        <Footer />
      </div>
    );
  }

  const videoPath = fetchSeriesByNum(media.alias, 1);

  const playerOptions = {
    autoplay: false,
    controls: true,
    responsive: true,
    fluid: true,
    sources: [
      {
        src: videoPath,
        type: 'video/mp4',
      }
    ]
  };

  const imagePath = media.hasImage === 1
    ? fetchMediaImage(media.alias)
    : "assets/no-image.png"

  return (
    <div>
      <Header />
      <div
        className={cl.media__page__container}
        style={{
          "--bg-image": `url(${imagePath})`,
        }}
      >
        <div className={cl.media__page}>
          <div className={cl.main__info}>
            <div className={cl.media__img__container} onClick={scrollToPlayer}>
              <img className={cl.media__img} src={imagePath} />
              <div className={cl.go__to__view}>
                <img
                  className={cl.go__to__view__img}
                  src="/assets/play.svg"
                  alt="play"
                />
                <h2 className={cl.go__to__view__text}>Смотреть</h2>
              </div>
            </div>
            <div className={cl.media__info}>
              <MediaPageTitle title={media.title} subtitle={media.subtitle} />
              <MediaInfo media={media}/>
            </div>
          </div>
          <MediaDescription media={media}/>
          <div className={cl.player__container} ref={playerRef}>
            <Player options={playerOptions}  title={media.subtitle} />
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
}
