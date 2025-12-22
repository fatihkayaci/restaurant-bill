import { useState, useEffect } from 'react'
import { useParams, Link, useNavigate } from 'react-router-dom'
import ProductCard from '../components/ProductCard'

function OrderPage() {
  const [products, setProducts] = useState([]);
  const { tableId } = useParams();
  const [cart, setCart] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetch("http://localhost:5006/api/Product") 
      .then(res => res.json())
      .then(data => setProducts(data))
      .catch(err => console.error(err));
  }, []);

  const addToCart = (product) => {
    setCart([...cart, product]); 
  };

  const totalAmount = cart.reduce((total, item) => total + item.price, 0);

  const handleCompleteOrder = () => {
    if (cart.length === 0) return;

    const orderData = {
      tableId: parseInt(tableId),
      productIds: cart.map(p => p.id)
    };

    fetch("http://localhost:5006/api/Order", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(orderData)
    })
    .then(res => {
      if (res.ok) {
        alert("Sipariş başarıyla mutfağa iletildi! 👨‍🍳");
        setCart([]);
        navigate("/");
      } else {
        alert("Bir hata oluştu!");
      }
    })
    .catch(err => console.error("Hata:", err));
  };

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col">
      
      <div className="bg-white shadow p-4 flex justify-between items-center sticky top-0 z-10">
        <Link to="/" className="text-blue-500 font-bold text-lg">← Masalar</Link>
        <h1 className="text-2xl font-bold text-gray-800">Masa {tableId}</h1>
        <div className="font-bold text-green-600 text-xl">Top: {totalAmount} ₺</div>
      </div>

      <div className="flex flex-1 overflow-hidden">
        
        {/* SOL TARA: MENÜ */}
        <div className="flex-1 overflow-y-auto p-4 bg-gray-100">
            <h2 className="text-xl font-bold mb-4 ml-4">Menü</h2>
            <div className="flex flex-wrap justify-center gap-4">
                {products.map((item) => (
                    <ProductCard 
                        key={item.id} 
                        product={item} 
                        onAdd={() => addToCart(item)} 
                    />
                ))}
            </div>
        </div>

        {/* SAĞ TARAF: ADİSYON */}
        <div className="w-80 bg-white shadow-xl border-l border-gray-200 flex flex-col">
            <div className="p-4 bg-gray-800 text-white text-center font-bold">
                ADİSYON
            </div>
            
            <div className="flex-1 overflow-y-auto p-4">
                {cart.length === 0 ? (
                    <p className="text-gray-400 text-center mt-10">Sepet boş...</p>
                ) : (
                    cart.map((item, index) => (
                        <div key={index} className="flex justify-between items-center border-b py-2">
                            <span className="text-sm font-medium">{item.name}</span>
                            <span className="text-sm font-bold text-gray-600">{item.price} ₺</span>
                        </div>
                    ))
                )}
            </div>

            <div className="p-4 border-t bg-gray-50">
                <div className="flex justify-between text-xl font-bold mb-4">
                    <span>Toplam:</span>
                    <span className="text-green-600">{totalAmount} ₺</span>
                </div>
                
                {/* Butona fonksiyonu bağladık */}
                <button 
                    onClick={handleCompleteOrder}
                    className="w-full bg-green-500 hover:bg-green-600 text-white py-3 rounded-lg font-bold transition">
                    Siparişi Tamamla ✅
                </button>
            </div>
        </div>

      </div>
    </div>
  )
}

export default OrderPage