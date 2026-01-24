import { useState, useEffect } from 'react';
import { getProducts } from '../services/api'
import './Style/ProductList.css'

function ProductList() {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        getProducts()
            .then(res => {
                console.log(res)
                setProducts(res.data); 
            })
            .catch(err => console.error("Veri çekilemedi:", err));
    }, []);

    return (
        <div className='product-container'>
            {products.map((product, index) => (
                <div className='product-card' key={index}>
                    <div className='product-image'>
                        <img 
                            src={product.image || 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?q=80&w=200&auto=format&fit=crop'} 
                            alt={product.name} 
                            onError={(e) => { e.target.src = 'https://via.placeholder.com/150'; }} 
                        />
                    </div>
                    <div className='product-info'>
                        <h4 className='product-name'>{product.name}</h4>
                        <p className='product-price'>$ {product.price}</p>
                        <p className='product-stock'>{product.stock || 10} Items Available</p>
                    </div>
                </div>
            ))}
        </div>
    );
}

export default ProductList;