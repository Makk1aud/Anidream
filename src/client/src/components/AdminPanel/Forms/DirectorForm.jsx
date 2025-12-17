import { useState } from "react";
import { api } from "../../../api/axios";
import cl from "./Form.module.css"

export default function DirectorForm() {
  const [fullName, setFullName] = useState("");

  const submit = async (e) => {
    e.preventDefault();
    try {
      await api.post("/director", { FullName: fullName });
      setFullName("");
      alert("Режиссёр добавлен");
    } catch (err) {
      console.error(err);
      alert("Ошибка при добавлении режиссёра, смотрите консоль");
    }
  };

  return (
    <form onSubmit={submit}>
      <h3>Добавить режиссёра</h3>

      <input
        placeholder="ФИО режиссёра"
        value={fullName}
        onChange={(e) => setFullName(e.target.value)}
        required
      />

      <button type="submit">Добавить</button>
    </form>
  );
}
