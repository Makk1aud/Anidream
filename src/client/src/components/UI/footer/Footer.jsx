import React from "react";
import cl from "./Footer.module.css";
import FooterButton from "../button/FooterButton";
import { Link, useNavigate } from "react-router-dom";

export default function Footer({onCatalogClick}) {

  const navigate = useNavigate();

  const handleLogoClick = (e) => {
    e.preventDefault();

    navigate('/home');

    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  }

  return (
    <div className={cl.footer}>
      <div className={cl.footer__wrapper}>
        <div className={cl.navigation}>
          <FooterButton text='Каталог' onClick={onCatalogClick} />
        </div>
        <div className={cl.slogan}>
          <p className={cl.slogan__text}>Anidream - аниме для мечтающих!</p>
          <Link onClick={handleLogoClick} to='/home'><img className={cl.logo} src="/logo/AnidreamLogo(red).svg" /></Link>
        </div>
      </div>
    </div>
  );
}
