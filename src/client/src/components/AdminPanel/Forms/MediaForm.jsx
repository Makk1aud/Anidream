import { useEffect, useState } from "react";
import {api} from "../../../api/axios"

export default function MediaForm() {
  const [genres, setGenres] = useState([]);
  const [studios, setStudios] = useState([]);
  const [directors, setDirectors] = useState([]);

  const [form, setForm] = useState({
    title: "",
    subtitle: "",
    alias: "",
    description: "",
    releasedate: "",
    rating: 0,
    totalEpisodes: 0,
    currentEpisodes: 0,
    genresIds: [],
    studioId: "",
    directorId: ""
  });

  useEffect(() => {
    api.get("/genre").then(r => setGenres(r.data));
    api.get("/studio").then(r => setStudios(r.data));
    api.get("/director").then(r => setDirectors(r.data));
  }, []);

  const submit = async (e) => {
    e.preventDefault();

    await api.post("/media", form);
    alert("Медиа добавлено");
  };

  return (
    <form onSubmit={submit}>
      <h3>Добавить медиа</h3>

      <input
        placeholder="Title"
        onChange={e => setForm({ ...form, title: e.target.value })}
      />

      <input
        placeholder="Subtitle"
        onChange={e => setForm({ ...form, subtitle: e.target.value })}
      />

      <input
        placeholder="Alias"
        onChange={e => setForm({ ...form, alias: e.target.value })}
      />

      <textarea
        placeholder="Описание"
        onChange={e => setForm({ ...form, description: e.target.value })}
      />

      <input
        type="date"
        onChange={e => setForm({ ...form, releasedate: e.target.value })}
      />

      <input
        type="number"
        step="0.1"
        placeholder="Рейтинг"
        onChange={e => setForm({ ...form, rating: Number(e.target.value) })}
      />

      <input
        type="number"
        placeholder="Всего эпизодов"
        onChange={e => setForm({ ...form, totalEpisodes: Number(e.target.value) })}
      />

      <input
        type="number"
        placeholder="Текущих эпизодов"
        onChange={e => setForm({ ...form, currentEpisodes: Number(e.target.value) })}
      />

      <label>Жанры</label>
      <select
        multiple
        onChange={(e) =>
          setForm({
            ...form,
            genresIds: Array.from(e.target.selectedOptions, o => o.value)
          })
        }
      >
        {genres.map(g => (
          <option key={g.id} value={g.id}>{g.title}</option>
        ))}
      </select>

      <label>Студия</label>
      <select onChange={e => setForm({ ...form, studioId: e.target.value })}>
        <option value="">Выберите студию</option>
        {studios.map(s => (
          <option key={s.id} value={s.id}>{s.title}</option>
        ))}
      </select>

      <label>Режиссёр</label>
      <select onChange={e => setForm({ ...form, directorId: e.target.value })}>
        <option value="">Выберите режиссёра</option>
        {directors.map(d => (
          <option key={d.id} value={d.id}>{d.FullName}</option>
        ))}
      </select>

      <button type="submit">Добавить</button>
    </form>
  );
}
