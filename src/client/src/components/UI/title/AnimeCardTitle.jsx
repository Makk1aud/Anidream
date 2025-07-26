import React from 'react'
import cl from './AnimeCardTitle.module.css'

export default function AnimeCardTitle(props) {
  return (
    <h2 className={cl.card__title}>{props.title}</h2>
  )
}
