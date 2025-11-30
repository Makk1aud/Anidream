import React from 'react'
import cl from './MediaCardTitles.module.css'

export default function MediaCardTitle(props) {
  return (
    <h2 className={cl.card__title}>{props.title}</h2>
  )
}
