import React from "react";
import cl from "./Header.module.css";
import HeaderButton from "../button/HeaderButton";

export default function Header() {
  return (
    <div className={cl.header__wrapper}>
      <header className={cl.header}>
        <h1>ANIDREAM</h1>
        <HeaderButton text="Каталог" />
      </header>
    </div>
  );
}
