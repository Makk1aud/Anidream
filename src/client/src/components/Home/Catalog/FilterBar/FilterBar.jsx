import React from "react";
import cl from "./FilterBar.module.css";

export default function FilterBar() {
  return (
    <div className={cl.wrapper}>
      <div className={cl.filter__bar}>
        <h3>Фильтры: </h3>
        <div className={cl.filters}>
          <div className={cl.genre__select__wrapper}>
            <select name="genre-select" id="" defaultValue={"genre"} className={cl.genre__select}>
              <option value="genre" disabled>
                Жанры
              </option>
              <option>Авантюра (Приключения)</option>
              <option>Вампиры</option>
              <option>Гарем</option>
              <option>Дзёсэй</option>
              <option>Драма</option>
              <option>Игра</option>
              <option>Комедия</option>
            </select>
          </div>
          <div className={cl.type__select__wrapper}>
            <select name="type-select" id="" className={cl.type__select} defaultValue='type'>
              <option value="type" disabled>Тип</option>
              <option>OVA</option>
              <option>ONA</option>
              <option>Фильм</option>
              <option>Спешл</option>
            </select>
          </div>
          <div className={cl.status__select__wrapper}>
            <select name="" id="" className={cl.status__select} defaultValue={'status'}>
              <option value="status" disabled>Статус</option>
              <option>Онгоинг</option>
              <option value="">Закончено</option>
            </select>
          </div>
        </div>
      </div>
    </div>
  );
}
