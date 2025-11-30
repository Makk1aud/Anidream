import React from 'react'
import cl from './MediaGenre.module.css'

export default function MediaGenre(props) {
  return (
    <div className={cl.genre}>
        <p>{props.genre.title}</p>
        <img className={cl.genre__image} src={props.genre.imgPath} />
    </div>
  )
}
