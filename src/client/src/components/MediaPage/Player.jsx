import React from "react";
import { useRef, useEffect } from "react";
import cl from "./Player.module.css";
import videojs from "video.js";
import "video.js/dist/video-js.css";

export default function Player(props) {
  const videoRef = useRef(null);
  const playerRef = useRef(null);

  const { options = {}, onReady } = props;

  // Инициализация плеера
  useEffect(() => {
    let player;

    // Проверяем, что элемент существует
    if (!videoRef.current) {
      console.warn("Video element ref is not available");
      return;
    }

    // Если плеер уже инициализирован, сначала удаляем его
    if (playerRef.current) {
      if (!playerRef.current.isDisposed()) {
        playerRef.current.dispose();
      }
      playerRef.current = null;
    }

    // Инициализируем новый плеер
    try {
      player = videojs(
        videoRef.current,
        {
          ...options,
          // Убеждаемся, что базовые опции установлены
          controls: options.controls !== undefined ? options.controls : true,
          autoplay: options.autoplay !== undefined ? options.autoplay : false,
          responsive: options.responsive !== undefined ? options.responsive : true,
          fluid: options.fluid !== undefined ? options.fluid : true,
        },
        function() {
          // Callback готовности
          console.log("Video.js player is ready");
          if (onReady) {
            onReady(player);
          }
        }
      );

      playerRef.current = player;

      // Если есть источники, устанавливаем их
      if (options.sources && options.sources.length > 0) {
        player.src(options.sources);
      }
    } catch (error) {
      console.error("Error initializing Video.js player:", error);
    }

    return () => {
      if (playerRef.current && !playerRef.current.isDisposed()) {
        playerRef.current.dispose();
        playerRef.current = null;
      }
    };
  }, [options.sources?.[0]?.src]); // Переинициализируем при изменении источника

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
      <div data-vjs-player style={{ width: '100%', maxWidth: '1200px', margin: '0 auto' }}>
        <video
          ref={videoRef}
          className="video-js vjs-big-play-centered"
          playsInline
          style={{ width: '100%', height: 'auto' }}
        />
      </div>
      {process.env.NODE_ENV === 'development' && (
        <div style={{ marginTop: '10px', fontSize: '12px', color: '#999' }}>
          Debug: Video source: {options.sources?.[0]?.src || 'No source'}
        </div>
      )}
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
