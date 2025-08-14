import React from "react";
import cl from "./Footer.module.css";
import FooterButton from "../button/FooterButton";

export default function Footer({onCatalogClick}) {
  return (
    <div className={cl.footer}>
      <div className={cl.footer__wrapper}>
        <div className={cl.navigation}>
          <FooterButton text='Каталог' onClick={onCatalogClick} />
        </div>
        <div className={cl.slogan}>
          <p className={cl.slogan__text}>Anidream - аниме для мечтающих!</p>
          <img className={cl.logo} src="/logo/AnidreamLogo(red).svg" />
        </div>
      </div>
    </div>
  );
}
