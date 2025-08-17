import React from "react";
import Header from '../components/UI/navbar/Header'
import SectionTitle from '../components/UI/title/SectionTitle'
import Catalog from '../components/Home/Catalog'
import Footer from "../components/UI/footer/Footer";
import cl from './Home.module.css'
import { useScroll } from "../hooks/useScroll";

export default function Home() {
  const [catalogRef, scrollToCatalog] = useScroll();

  return (
    <div className={cl.home}>
      <Header />
      <SectionTitle title="Каталог" />
      <Catalog ref={catalogRef}/>
      <Footer onCatalogClick={scrollToCatalog}/>
    </div>
  );
}
