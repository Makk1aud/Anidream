import React from 'react'
import cl from './AnimeCardTitles.module.css'

export default function AnimeCardTitle(props) {
  return (
    <h2 className={cl.card__title}>{props.title}</h2>
  )
}
