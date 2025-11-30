import React from 'react'
import cl from './MediaPageTitle.module.css'

export default function MediaPageTitle(props) {
  return (
    <div className={cl.Media__page__title}>
      <h1>{props.title}</h1>
      <h2>{props.subtitle}</h2>
    </div>
  )
}
