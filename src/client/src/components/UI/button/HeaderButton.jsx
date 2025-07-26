import React from "react";
import cl from "./HeaderButton.module.css";

export default function HeaderButton(props) {
  return <a className={cl.btn}>{props.text}</a>;
}
