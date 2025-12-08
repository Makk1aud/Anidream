import React from "react";
import { useRef, useEffect, useLayoutEffect } from "react";
import ReactPlayer from "react-player";
import cl from "./Player.module.css";
import videojs from "video.js";
import "video.js/dist/video-js.css";

export default function Player(props) {
  const videoRef = useRef(null);
  const playerRef = useRef();

  const { options = {}, onReady } = props;

  useLayoutEffect(() => {

    console.log("useEffect запущен, videoRef.current:", videoRef.current);
    const player = (playerRef.current = videojs(
      videoRef.current,
      options,
      () => {
        onReady && onReady(player);
      }
    ));

    return () => {
      if (player) {
        player.dispose();
        playerRef.current = null;
      }
    };
  }, [options, onReady]);

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
