import { useState, useEffect } from "react";
import { api } from "../../../api/axios";
import cl from "./Form.module.css"

export default function StudioForm() {
  const [title, setTitle] = useState("");
  const [studios, setStudios] = useState([]);
  const [deleteId, setDeleteId] = useState("");

  useEffect(() => {
    api.get("/studio").then(r => setStudios(r.data));
  }, []);

  const submit = async (e) => {
    e.preventDefault();
    await api.post("/studio", { Title: title });
    setTitle("");
    const r = await api.get("/studio");
    setStudios(r.data);
    alert("Студия добавлена");
  };

  const deleteStudio = async () => {
    if (!deleteId) return alert("Выберите студию для удаления");

    try {
      await api.delete(`/studio/${deleteId}`);
      const r = await api.get("/studio");
      setStudios(r.data);
      setDeleteId("");
      alert("Студия удалена");
    } catch (err) {
      console.error(err);
      alert("Ошибка при удалении студии");
    }
  };

  return (
    <form onSubmit={submit} className={cl.adminForm}>
      <h3>Добавить студию</h3>

      <input
        placeholder="Название студии"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />

      <button type="submit">Добавить</button>

      <div className={cl.delete__block}>
        <h3>Удалить студию</h3>
        <select value={deleteId} onChange={e => setDeleteId(e.target.value)}>
          <option value="">Выберите студию</option>
          {studios.map(s => (
            <option key={s.studioId} value={s.studioId}>{s.title}</option>
          ))}
        </select>
        <button type="button" onClick={deleteStudio}>Удалить</button>
      </div>
    </form>
  );
}
