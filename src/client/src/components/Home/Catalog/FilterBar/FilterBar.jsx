import React, { useState } from "react";
import cl from "./FilterBar.module.css";
import FilterSelect from "../../../UI/select/FilterSelect/FilterSelect";
import FilterSlider from "../../../UI/slider/FilterSlider";

export default function FilterBar() {
  const genreOptions = [
    { value: "action", label: "Боевик" },
    { value: "biography", label: "Биография" },
    { value: "war", label: "Военный" },
    { value: "detective", label: "Детекив" },
    { value: "documentary", label: "Документальный" },
    { value: "drama", label: "Драма" },
    { value: "comedy", label: "Комедия" },
    { value: "crime", label: "Криминал" },
    { value: "romantic", label: "Мелодрама" },
    { value: "kids", label: "Мультсериал" },
    { value: "adventure", label: "Приключения" },
    { value: "family", label: "Семейный" },
    { value: "sport", label: "Спорт" },
    { value: "thriller", label: "Триллер" },
    { value: "horror", label: "Ужасы" },
    { value: "fantasy", label: "Фантастика" }
  ];

  const typeOptions = [
    { value: "tv-series", label: "Сериал" },
    { value: "movie", label: "Фильм" }
  ];

  const statusOptions = [
    { value: "on-going", label: "Продолжается" },
    { value: "finished", label: "Закончено" },
  ];

  const [currentGenre, setCurrentGenre] = useState("");
  const [currentType, setCurrentType] = useState("");
  const [currentStatus, setCurrentStatus] = useState("");

  const getValue = (state, options) => {
    return state ? options.find((c) => c.value === state) : "";
  };

  return (
    <div className={cl.wrapper}>
      <div className={cl.filter__bar}>
        <h3>Фильтры: </h3>
        <div className={cl.filters}>
          <div className={cl.selects}>
            <div className={cl.genre__select__wrapper}>
              <FilterSelect
                className={cl.genre__select}
                value={() => getValue(currentGenre, genreOptions)}
                options={genreOptions}
                isMulti={true}
                placeholder="Жанр"
              />
            </div>
            <div className={cl.type__select__wrapper}>
              <FilterSelect options={typeOptions} placeholder="Тип" />
            </div>
            <div className={cl.status__select__wrapper}>
              <FilterSelect options={statusOptions} placeholder="Статус" />
            </div>
          </div>

          <button className={cl.search__button}>
            <img className={cl.search__button__img} src="/assets/search-button.png"/>
          </button>

          {/* <div className="year__slider">
            <FilterSlider />
          </div> */}
        </div>
      </div>
    </div>
  );
}
