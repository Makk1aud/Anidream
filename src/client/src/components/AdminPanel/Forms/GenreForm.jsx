import { useState } from "react";
import { api } from "../../../api/axios";

export default function GenreForm() {
  const [title, setTitle] = useState("");
  const [alias, setAlias] = useState("");

  const submit = async (e) => {
    e.preventDefault();

    await api.post("/genre", {
      Title: title,
      Alias: alias
    });

    setTitle("");
    setAlias("");
    alert("Жанр добавлен");
  };

  return (
    <form onSubmit={submit}>
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
    </form>
  );
}
