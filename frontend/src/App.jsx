import { Routes, Route } from 'react-router-dom';

import Tables from './pages/Tables.jsx';
import Header from './components/Header.jsx';
import OrderDetail from './pages/OrderDetail.jsx';

import './App.css';

function App() {
  return (
    <div className='container'>
      <Header/>
      <div className="content">
        <Routes>
          <Route path="/" element={<Tables />} />
          <Route path="/order-detail/:id" element={<OrderDetail />} />
          {/* <Route path="/menus" element={<Menus/>} /> */}
        </Routes>
      </div>
    </div>
  );
}

export default App;