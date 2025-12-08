import React from "react";
import { useRef, useEffect } from "react";
import cl from "./Player.module.css";
import videojs from "video.js";
import "video.js/dist/video-js.css";

export default function Player(props) {
  const videoRef = useRef(null);
  const playerRef = useRef(null);

  const { options = {}, onReady } = props;

  // Инициализация плеера (только один раз)
  useEffect(() => {
    // Проверяем, что элемент существует
    if (!videoRef.current) {
      return;
    }

    // Инициализируем новый плеер только если его ещё нет
    if (!playerRef.current) {
      const player = videojs(
        videoRef.current,
        options,
        () => {
          onReady && onReady(player);
        }
      );

      playerRef.current = player;
    }

    return () => {
      if (playerRef.current && !playerRef.current.isDisposed()) {
        playerRef.current.dispose();
        playerRef.current = null;
      }
    };
  }, []); // Инициализация только один раз при монтировании

  // Обновление источников при изменении options
  useEffect(() => {
    if (playerRef.current && options.sources && options.sources.length > 0) {
      playerRef.current.src(options.sources);
    }
  }, [options.sources?.[0]?.src]); // Обновляем только при изменении URL

  // //изменения options после того, как плеер уже инициализирован
  // useEffect(() => {
  //   const player = playerRef.current;
  //   if (player && options.sources) {
  //     player.src(options.sources); // Обновляем источник видео
  //   }
  //   if (player && options.poster) {
  //     player.poster(options.poster); // Обновляем постер
  //   }
  // }, [options]); // Срабатывает при изменении опций

  return (
    <div className={cl.player__container}>
      <div className={cl.player__name}>
        <h2>{`Смотреть ${props.title}`}</h2>
      </div>
      <div data-vjs-player>
        <video ref={videoRef} className="video-js vjs-big-play-centered"/>
      </div>
    </div>
  );
}

// export default function Player(props) {
//   return (
//     <div className={cl.player__container}>
//       <div className={cl.player__name}>
//         <h2>{`Смотреть ${props.title}`}</h2>
//       </div>

//       <ReactPlayer
//         className={cl.player}
//         src={props.url}
//         width="100%"
//         height="100%"
//         controls
//       />
//     </div>
//   );
// }
