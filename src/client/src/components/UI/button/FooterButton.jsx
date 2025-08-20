import React from 'react'
import cl from './FooterButton.module.css'

export default function FooterButton({text, onClick}) {
  return (
    <a onClick={onClick} className={cl.footer__button}>{text}</a>
  )
}
