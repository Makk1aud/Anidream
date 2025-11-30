import React from "react";
import ReactPlayer from "react-player";
import cl from "./Player.module.css";

export default function Player(props) {
  return (
    <div className={cl.player__container}>
      <div className={cl.player__name}>
        <h2>{`Смотреть ${props.title}`}</h2>
      </div>

      <ReactPlayer
        className={cl.player}
        src={props.url}
        width="100%"
        height="100%"
        controls
      />
    </div>
  );
}
