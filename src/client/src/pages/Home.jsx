import React from "react";
import Header from '../components/UI/navbar/Header'
import SectionTitle from '../components/UI/title/SectionTitle'
import Catalog from '../components/Home/Catalog'

export default function Home() {
  return (
    <div>
      <Header />
      <SectionTitle title="Каталог" />
      <Catalog />
    </div>
  );
}
