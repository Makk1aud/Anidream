import React, { useState, useEffect } from "react";
import ReactPlayer from "react-player";
import cl from "./Player.module.css";
import { fetchSeriesByNum } from "../../api/mediaAPI";
import EpisodeSelector from "./EpisodeSelector/EpisodeSelector";

export default function Player({ media }) {
  const [currentEpisode, setCurrentEpisode] = useState(1);

 const [videoUrl, setVideoUrl] = useState(
    fetchSeriesByNum(media.alias, currentEpisode)
  );

  useEffect(() => {
    if(media.totalEpisodes > 1) {
      setVideoUrl(fetchSeriesByNum(media.alias, currentEpisode));
    } else {
      setVideoUrl(fetchSeriesByNum(media.alias, 1));
    }
  }, [currentEpisode, media.alias, media.totalEpisodes])
  
  return (
    <div className={cl.player__container}>
      <div className={cl.player__name}>
        <h2>{`Смотреть ${media.subtitle}`}</h2>
      </div>

      <EpisodeSelector
        media={media}
        currentEpisode={currentEpisode}
        onChange={setCurrentEpisode}
      />

      <ReactPlayer
        className={cl.player}
        src={videoUrl}
        width="100%"
        height="100%"
        controls
      />
    </div>
  );
}
