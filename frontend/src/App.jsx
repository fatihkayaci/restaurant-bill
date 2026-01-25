import Tables from './pages/Tables.jsx';
import Header from './components/Header.jsx';
import './App.css'
function App() {
  return (
    <div className='container'>
      <Header/>
      <div className="content">
        
        <Tables/>
      </div>
    </div>
  );
}

export default App;



{/* <Routes>
  <Route path="/" element={<Tables />} />
  <Route path="/tables" element={<Tables/>} />
  <Route path="/menus" element={<Menus/>} />
</Routes> */}