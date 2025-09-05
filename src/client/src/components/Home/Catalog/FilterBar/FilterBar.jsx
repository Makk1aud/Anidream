import React, { useState } from "react";
import cl from "./FilterBar.module.css";
import FilterSelect from "../../../UI/select/FilterSelect";
import FilterSlider from "../../../UI/slider/FilterSlider";

export default function FilterBar() {
  const genreOptions = [
    { value: "adventure", label: "Приключения" },
    { value: "vampire", label: "Вампиры" },
    { value: "garem", label: "Гарем" },
    { value: "djesay", label: "Дзёсэй" },
    { value: "drama", label: "Драма" },
    { value: "game", label: "Игра" },
    { value: "comedy", label: "Комедия" },
  ];

  const typeOptions = [
    { value: "ova", label: "OVA" },
    { value: "ona", label: "ONA" },
    { value: "movie", label: "Фильм" },
    { value: "special", label: "Спешл" },
  ];

  const statusOptions = [
    { value: "ongoing", label: "Онгоинг" },
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
          <div className="year__slider">
            <FilterSlider />
          </div>
        </div>
      </div>
    </div>
  );
}
