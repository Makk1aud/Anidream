import React from 'react'
import cl from './Header.module.css'
import HeaderButton from './UI/button/HeaderButton'


export default function Header() {
  return (
    <header className={cl.header}>
      <h1>ANIDREAM</h1>
      <HeaderButton text='Каталог' />
    </header>
  )
}
