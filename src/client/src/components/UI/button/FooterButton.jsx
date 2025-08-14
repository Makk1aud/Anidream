import React from 'react'
import cl from './FooterButton.module.css'

export default function FooterButton({text}) {
  return (
    <a className={cl.footer__button}>{text}</a>
  )
}
