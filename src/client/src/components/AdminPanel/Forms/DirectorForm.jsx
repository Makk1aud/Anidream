import { useState, useEffect } from "react";
import { api } from "../../../api/axios";
import cl from "./Form.module.css"

export default function DirectorForm() {
  const [fullName, setFullName] = useState("");
  const [directors, setDirectors] = useState([]);
  const [deleteId, setDeleteId] = useState("");

  useEffect(() => {
    api.get("/director").then(r => setDirectors(r.data));
  }, []);

  const submit = async (e) => {
    e.preventDefault();
    try {
      await api.post("/director", { FullName: fullName });
      setFullName("");
      const r = await api.get("/director");
      setDirectors(r.data);
      alert("Режиссёр добавлен");
    } catch (err) {
      console.error(err);
      alert("Ошибка при добавлении режиссёра, смотрите консоль");
    }
  };

  const deleteDirector = async () => {
    if (!deleteId) return alert("Выберите режиссёра для удаления");

    try {
      await api.delete(`/director/${deleteId}`);
      const r = await api.get("/director");
      setDirectors(r.data);
      setDeleteId("");
      alert("Режиссёр удалён");
    } catch (err) {
      console.error(err);
      alert("Ошибка при удалении режиссёра");
    }
  };

  return (
    <form onSubmit={submit} className={cl.adminForm}>
      <h3>Добавить режиссёра</h3>

      <input
        placeholder="Режиссёр"
        value={fullName}
        onChange={(e) => setFullName(e.target.value)}
        required
      />

      <button type="submit">Добавить</button>

      <div className={cl.delete__block}>
        <h3>Удалить режиссёра</h3>
        <select value={deleteId} onChange={e => setDeleteId(e.target.value)}>
          <option value="">Выберите режиссёра</option>
          {directors.map(d => (
            <option key={d.directorId} value={d.directorId}>{d.fullName}</option>
          ))}
        </select>
        <button type="button" onClick={deleteDirector}>Удалить</button>
      </div>
    </form>
  );
}
