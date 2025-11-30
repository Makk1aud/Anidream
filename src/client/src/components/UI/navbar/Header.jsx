import React from "react";
import cl from "./Header.module.css";
import HeaderButton from "../button/HeaderButton";
import { Link } from "react-router-dom";
import Logo from "../Logo";

export default function Header({onCatalogClick}) {
  return (
    <div className={cl.header__wrapper}>
      <header className={cl.header}>
        <Link className={cl.link} to='/home'><Logo /></Link>
        <HeaderButton onClick={onCatalogClick} text="Каталог" href='/home'/>
      </header>
    </div>
  );
}
