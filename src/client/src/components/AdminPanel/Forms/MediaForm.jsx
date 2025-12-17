import { useEffect, useState } from "react";
import {api} from "../../../api/axios"
import cl from "./Form.module.css"

export default function MediaForm() {
  const [genres, setGenres] = useState([]);
  const [studios, setStudios] = useState([]);
  const [directors, setDirectors] = useState([]);
  const [medias, setMedias] = useState([]);
  const [image, setImage] = useState("");
  const [file, setFile] = useState(null);
  const [deleteId, setDeleteId] = useState(""); 

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
    api.get("/media").then(r => setMedias(r.data));
  }, []);

  useEffect(() => {
  api.get("/director")
     .then(r => {
       console.log("Directors:", r.data); 
       setDirectors(r.data);
     })
     .catch(err => console.error(err));
  }, []);

  const submit = async (e) => {
    e.preventDefault();

    await api.post("/media", form);
    alert("Медиа добавлено");
    const r = await api.get("/media");
  };

  const deleteMedia = async () => {
    if (!deleteId) return alert("Выберите медиа для удаления");

    try {
      await api.delete(`/media/${deleteId}`);
      alert("Медиа удалено");
      const r = await api.get("/media"); 
      setMedias(r.data);
      setDeleteId("");
    } catch (err) {
      console.error(err);
      alert("Ошибка при удалении медиа");
    }
  };

  const uploadImage = async () => {
    if (!image || !file) return alert("Выберите медиа и файл для загрузки");

    const formData = new FormData();
    formData.append("file", file);

    try {
      await api.post(`/storage/media/image/${image}`, formData, {
      headers: { "Content-Type": "multipart/form-data" }
      });
      setFile(null);
      setImage("");
      alert("Изображение загружено");

      const r = await api.get("/media");
      setMedias(r.data);
    } catch (err) {
      console.error(err);
      alert("Ошибка при загрузке изображения");
    }
  };


  return (
    <form onSubmit={submit} className={cl.adminForm}>
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
        value={form.genresIds}
        onChange={(e) =>
          setForm({
            ...form,
            genresIds: Array.from(e.target.selectedOptions, o => o.value)
          })
        }
      >
        {genres.map(g => (
          <option key={g.genreId} value={g.genreId}>{g.title}</option>
        ))}
      </select>

      <label>Студия</label>
      <select onChange={e => setForm({ ...form, studioId: e.target.value })}>
        <option value="">Выберите студию</option>
        {studios.map(s => (
          <option key={s.studioId} value={s.studioId}>{s.title}</option>
        ))}
      </select>

      <label>Режиссёр</label>
      <select onChange={e => setForm({ ...form, directorId: e.target.value })}>
        <option value="">Выберите режиссёра</option>
        {directors.map(d => (
          <option key={d.directorId} value={d.directorId}>{d.fullName}</option>
        ))}
      </select>

      <button type="submit">Добавить</button>

      <div className={cl.delete__block} style={{ marginTop: "40px" }}>
      <h3>Добавить изображение к медиа</h3>
      <select value={image} onChange={e => setImage(e.target.value)}>
      <option value="">Выберите медиа</option>
      {medias.map(m => <option key={m.mediaId} value={m.alias}>{m.title}</option>)}
      </select>
      <input type="file" onChange={e => setFile(e.target.files[0])} />
      <button type="button" onClick={uploadImage}>Загрузить</button>
      </div>


      <div className={cl.delete__block} style={{ marginTop: "40px" }}>
        <h3>Удалить медиа</h3>
        <select value={deleteId} onChange={e => setDeleteId(e.target.value)}>
          <option value="">Выберите медиа</option>
          {medias.map(m => <option key={m.mediaId} value={m.mediaId}>{m.title}</option>)}
        </select>
        <button type="button" onClick={deleteMedia}>Удалить</button>
      </div>
    </form>
  );
}
