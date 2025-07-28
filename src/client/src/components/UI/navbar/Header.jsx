import React from "react";
import cl from "./Header.module.css";
import HeaderButton from "../button/HeaderButton";
import { Link } from "react-router-dom";

export default function Header() {
  return (
    <div className={cl.header__wrapper}>
      <header className={cl.header}>
        <Link className={cl.link} to='/home'><h1>ANIDREAM</h1></Link>
        <HeaderButton text="Каталог" href='/home' />
      </header>
    </div>
  );
}
