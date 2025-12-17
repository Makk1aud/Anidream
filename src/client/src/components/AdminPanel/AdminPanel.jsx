// pages/admin/AdminLayout.jsx
import { Outlet, Link } from "react-router-dom";
import Header from "../UI/navbar/Header";
import cl from "./AdminPanel.module.css"

export default function AdminPanel() {
  return (
    <div>
      <Header />

      <div className={cl.container}>
        <aside style={{ width: 200 }} className={cl.links}>
          <Link to="media">Медиа</Link><br/>
          <Link to="genres">Жанры</Link><br/>
          <Link to="studios">Студии</Link><br/>
          <Link to="directors">Режиссёры</Link>
        </aside>

        <main style={{ padding: 20 }}>
          <Outlet />
        </main>
      </div>
    </div>
  );
}
