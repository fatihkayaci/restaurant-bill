import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { getTables } from '../services/api'
import './Style/TableList.css'
function TableList() {
    const navigate = useNavigate();
    const [tables, setTables] = useState([]);

    useEffect(() => {
        getTables()
            .then(res => {
                setTables(res.data); 
            })
            .catch(err => console.error("Veri çekilemedi:", err));
    }, []);

    return(
        <div className='table-container'>
            {tables.map((table, index) => (
                <button
                    key={table.id}
                    className={`table-button ${table.status === 1 ? 'table-full' : 'table-empty'}`}
                    onClick={() => navigate(`/order-detail/${table.id}`)}
                >
                    <div>
                        Masa Adı: {table.name}
                    </div>
                </button>
            ))}
        </div>
    )
}

export default TableList;