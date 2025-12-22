// 1. onAdd diye bir özellik (prop) kabul etmesini söyledik
function ProductCard({ product, onAdd }) {
  return (
    <div className="bg-white border border-gray-200 rounded-lg shadow-md p-4 m-4 w-64 text-center hover:shadow-xl transition-shadow duration-300 flex flex-col justify-between">
      
      <div>
        <div className="text-4xl mb-3">🍽️</div>
        <h3 className="text-xl font-semibold text-gray-800 mb-2">
          {product.name}
        </h3>
        <p className="text-green-600 font-bold text-lg mb-4">
          {product.price} ₺
        </p>
      </div>
      
      {/* 2. Butona basılınca 'onAdd' fonksiyonunu çalıştır dedik */}
      <button 
        onClick={onAdd}
        className="bg-orange-500 hover:bg-orange-600 text-white font-bold py-2 px-4 rounded w-full transition-colors active:scale-95">
        Sepete Ekle
      </button>

    </div>
  )
}

export default ProductCard;