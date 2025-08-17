import React from 'react'
import cl from './SectionTitle.module.css'

export default function SectionTitle(props) {
  return (
    <h1 className={cl.section__title}>{props.title}</h1>
  )
}
