import React from "react";
import cl from "./MediaDescription.module.css";

export default function MediaDescription({media}) {
  return (
    <div className={cl.media__description__container}>
      <p className={cl.media__description}>
        {media.description}
      </p>

      <img className={cl.logo} src='/logo/moviedream.svg'/>
    </div>
  );
}
