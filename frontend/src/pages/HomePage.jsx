import { useState, useEffect } from 'react'
import TableCard from '../components/TableCard'

function HomePage() {
  const [tables, setTables] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5006/api/Table") 
      .then(res => res.json())
      .then(data => setTables(data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 p-10">
      <h1 className="text-4xl font-bold text-center text-blue-900 mb-10">
        🍽️ Restoran Masaları
      </h1>
      
      <div className="flex flex-wrap justify-center">
        {tables.length === 0 ? (
          <p className="text-xl text-gray-500">Masalar yükleniyor...</p>
        ) : (
          tables.map((table) => (
            <TableCard key={table.id} table={table} />
          ))
        )}
      </div>
    </div>
  )
}

export default HomePage