import React from 'react'
import cl from './SectionTitle.module.css'

export default function SectionTitle(props) {
  return (
    <h1 className={cl.section__title} id={props.id}>{props.title}</h1>
  )
}
