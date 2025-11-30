import React from 'react'
import cl from './MediaCardTitles.module.css'

export default function MediaCardSubTitle(props) {
  return (
    <h3 className={cl.card__subtitle}>{props.title}</h3>
  )
}
