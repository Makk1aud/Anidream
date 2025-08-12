import React from 'react'
import cl from './AnimePageTitle.module.css'

export default function AnimePageTitle(props) {
  return (
    <div className={cl.anime__page__title}>
      <h1>{props.title}</h1>
      <h2>{props.subtitle}</h2>
    </div>
  )
}
