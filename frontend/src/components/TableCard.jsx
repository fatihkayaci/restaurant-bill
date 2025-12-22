import { useNavigate } from 'react-router-dom' // Sayfa değiştirmek için kanca

function TableCard({ table }) {
  const navigate = useNavigate();

  return (
    <div 
      // Karta tıklanınca sipariş sayfasına git ve masa ID'sini de götür
      onClick={() => navigate(`/order/${table.id}`)}
      
      className="cursor-pointer bg-white border-2 border-gray-300 rounded-xl shadow-lg hover:shadow-2xl hover:border-blue-500 transition-all duration-300 w-40 h-40 flex flex-col items-center justify-center m-4"
    >
      
      {/* Masa İkonu */}
      <div className="text-5xl mb-2">🪑</div>
      
      {/* Masa Adı */}
      <h3 className="text-xl font-bold text-gray-700">{table.tableName}</h3>
      
      {/* Durum (Şimdilik statik Boş yazalım) */}
      <span className="text-sm text-green-600 font-semibold mt-1">
        ● Boş
      </span>
      
    </div>
  )
}

export default TableCard