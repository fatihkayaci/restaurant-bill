import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { getProducts, getCategories } from '../services/api'
import './Style/OrderDetail.css';

function OrderDetail() {
    const { id } = useParams(); // URL'den masa numarasını çektik (örn: 5)

    const [products, setProducts] = useState([]);
    const [categories, setCategories] = useState([]);
    
    useEffect(() => {
        getProducts()
            .then(res => {
                setProducts(res.data); 
            })
            .catch(err => console.error("Veri çekilemedi:", err));
    }, []);

    useEffect(() => {
        getCategories()
            .then(res => {
                setCategories(res.data); 
            })
            .catch(err => console.error("Veri çekilemedi:", err));
    }, []);

    return (
        <div className="order-page">
        
        {/* --- SOL TARAF: MENÜ --- */}
        <div className="menu-section">
            {/* Üstte Kategori Butonları */}
            <div className="category-tabs">
            {categories.map((cat, index) => (
                <button key={index} className={`cat-btn ${index === 0 ? 'active' : ''}`}>
                {cat.name}
                </button>
            ))}
            </div>

            {/* Altta Ürün Kartları */}
            <div className="product-grid">
            {products.map((product) => (
                <div key={product.id} className="product-card">
                <div className="product-img">
                    <img 
                        src={product.image || 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=200&auto=format&fit=crop'} 
                        alt={product.name} 
                        onError={(e) => { e.target.src = 'https://via.placeholder.com/150'; }} />
                    </div>
                <div className="product-info">
                    <h3>{product.name}</h3>
                    <span>{product.price} ₺</span>
                </div>
                </div>
            ))}
            </div>
        </div>

        {/* --- SAĞ TARAF: ADİSYON (SEPET) --- */}
        <div className="cart-section">
            <div className="cart-header">
                <h2>Masa {id}</h2>
                <span className="order-id">Adisyon #8432</span>
            </div>

            {/* Sepetteki Ürünler Listesi (Şimdilik boş örnek) */}
            <div className="cart-items">
                <div className="cart-item">
                    <div className="item-detail">
                        <span>Izgara Köfte</span>
                        <small>₺250 x 1</small>
                    </div>
                    <span className="item-price">250 ₺</span>
                </div>
                
                <div className="cart-item">
                    <div className="item-detail">
                        <span>Ayran</span>
                        <small>₺30 x 2</small>
                    </div>
                    <span className="item-price">60 ₺</span>
                </div>
            </div>

            {/* Alt Kısım: Toplam ve Butonlar */}
            <div className="cart-footer">
                <div className="total-row">
                    <span>Toplam Tutar</span>
                    <span className="total-price">310 ₺</span>
                </div>
                <button className="pay-btn">Ödeme Al</button>
            </div>
        </div>

        </div>
    );
}

export default OrderDetail;