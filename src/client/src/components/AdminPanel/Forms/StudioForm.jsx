import { useState } from "react";
import { api } from "../../../api/axios";

export default function StudioForm() {
  const [title, setTitle] = useState("");

  const submit = async (e) => {
    e.preventDefault();

    await api.post("/studio", {
      Title: title
    });

    setTitle("");
    alert("Студия добавлена");
  };

  return (
    <form onSubmit={submit}>
      <h3>Добавить студию</h3>

      <input
        placeholder="Название студии"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />

      <button type="submit">Добавить</button>
    </form>
  );
}
