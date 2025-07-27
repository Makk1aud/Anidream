import './App.css';
import Catalog from './components/Catalog';
import Header from './components/UI/navbar/Header';
import SectionTitle from './components/UI/title/SectionTitle'

function App() {
  return (
    <div className="App">
      <Header />
      <SectionTitle title='Каталог'/>
      <Catalog />
    </div>
  );
}

export default App;
