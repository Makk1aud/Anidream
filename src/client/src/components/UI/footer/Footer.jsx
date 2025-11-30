import React from "react";
import cl from "./Footer.module.css";
import FooterButton from "../button/FooterButton";
import { Link, useLocation, useNavigate } from "react-router-dom";
import Logo from "../Logo";

export default function Footer() {
  const navigate = useNavigate();
  const location = useLocation();

  const handleClickScroll = (e, scrollTargetId = null) => {
    e.preventDefault();

    if (location.pathname === "/home") {
      if (scrollTargetId) {
        const targetEl = document.getElementById(scrollTargetId);

        if (targetEl) {
          targetEl.scrollIntoView({
            behavior: "smooth",
            block: "start",
          });
        }
      } else {
        window.scrollTo({
          top: 0,
          behavior: "smooth",
        });
      }
    } else {
      navigate("/home");

      if (scrollTargetId) {
        setTimeout(() => {
          const targetEl = document.getElementById(scrollTargetId);

          if (targetEl) {
            targetEl.scrollIntoView({
              behavior: "smooth",
              block: "start",
            });
          }
        }, 100);
      } else {
        window.scrollTo({
          top: 0,
          behavior: "smooth",
        });
      }
    }
  };

  return (
    <div className={cl.footer}>
      <div className={cl.footer__wrapper}>
        <div className={cl.navigation}>
          <FooterButton
            text="Каталог"
            onClick={(e) => handleClickScroll(e, "catalog-title")}
          />
        </div>
        <div className={cl.slogan}>
          <p className={cl.slogan__text}>moviedream - фильмы/сериалы для мечтающих!</p>
          <Link onClick={handleClickScroll} to="/home">
            <Logo />
          </Link>
        </div>
      </div>
    </div>
  );
}
