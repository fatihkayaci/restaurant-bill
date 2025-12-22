import { BrowserRouter, Routes, Route } from 'react-router-dom'
import HomePage from './pages/HomePage'
import OrderPage from './pages/OrderPage'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* Ana Sayfa */}
        <Route path="/" element={<HomePage />} />
        
        {/* Sipariş Sayfası */}
        <Route path="/order/:tableId" element={<OrderPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App