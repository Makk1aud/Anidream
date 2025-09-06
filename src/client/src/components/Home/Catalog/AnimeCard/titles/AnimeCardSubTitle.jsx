import React from 'react'
import cl from './AnimeCardTitles.module.css'

export default function AnimeCardSubTitle(props) {
  return (
    <h3 className={cl.card__subtitle}>{props.title}</h3>
  )
}
