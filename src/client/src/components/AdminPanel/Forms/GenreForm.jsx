import { useState, useEffect } from "react";
import { api } from "../../../api/axios";
import cl from "./Form.module.css"

export default function GenreForm() {
  const [title, setTitle] = useState("");
  const [alias, setAlias] = useState("");
  const [genres, setGenres] = useState([]);
  const [deleteId, setDeleteId] = useState("");

  useEffect(() => {
    api.get("/genre").then(r => setGenres(r.data));
  }, []);

  const submit = async (e) => {
    e.preventDefault();

    await api.post("/genre", {
      Title: title,
      Alias: alias
    });

    setTitle("");
    setAlias("");
    const r = await api.get("/genre");
    setGenres(r.data);
    alert("Жанр добавлен");
  };

  const deleteGenre = async () => {
    if (!deleteId) return alert("Выберите жанр для удаления");

    try {
      await api.delete(`/genre/${deleteId}`);
      const r = await api.get("/genre");
      setGenres(r.data);
      setDeleteId("");
      alert("Жанр удален");
    } catch (err) {
      console.error(err);
      alert("Ошибка при удалении жанра");
    }
  };

  return (
    <form onSubmit={submit} className={cl.adminForm}>
      <h3>Добавить жанр</h3>

      <input
        placeholder="Название"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />

      <input
        placeholder="Alias"
        value={alias}
        onChange={(e) => setAlias(e.target.value)}
        required
      />

      <button type="submit">Добавить</button>

      <div className={cl.delete__block}>
        <h3>Удалить жанр</h3>
        <select value={deleteId} onChange={e => setDeleteId(e.target.value)}>
          <option value="">Выберите жанр</option>
          {genres.map(g => <option key={g.genreId} value={g.genreId}>{g.title}</option>)}
        </select>
        <button type="button" onClick={deleteGenre}>Удалить</button>
      </div>
    </form>
  );
}
