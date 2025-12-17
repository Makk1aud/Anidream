import React, { useState } from "react";
import cl from "./FilterBar.module.css";
import FilterSelect from "../../../UI/select/FilterSelect/FilterSelect";
import FilterSlider from "../../../UI/slider/FilterSlider";

export default function FilterBar({onSearch}) {

  const [searchTitle, setSearchTitle] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (onSearch) {
      onSearch(searchTitle);
    }
  }

  const handleTitleChange = (e) => {
    setSearchTitle(e.target.value);
  }

  const getValue = (state, options) => {
    return state ? options.find((v) => v.value === state) : "";
  };

  return (
    <div className={cl.wrapper}>
      <div className={cl.filter__bar}>
        <h3>Поиск: </h3>
        <div className={cl.filters}>
          <form onSubmit={handleSubmit} className={cl.search__form}>
            <input
              type="text"
              placeholder="Введите название"
              value={searchTitle}
              onChange={handleTitleChange}
              className={cl.search__input}
            />
          <button className={cl.search__button}>
            <img className={cl.search__button__img} src="/assets/search-button.png"/>
          </button>
          </form>

          {/* <div className="year__slider">
            <FilterSlider />
          </div> */}
        </div>
      </div>
    </div>
  );
}
