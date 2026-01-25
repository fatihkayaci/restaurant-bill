import { NavLink } from 'react-router-dom';
import './Style/Header.css'

function Header() {
    return (
        <div className="header-container">
            <div className="header-left">
                <div className="brand">
                    <h1>RestoOrder</h1>
                </div>
                
                <nav className="nav-menu">
                    <NavLink to="/" className="nav-item">Masalar</NavLink>
                    <NavLink to="/mutfak" className="nav-item">Mutfak Durumu</NavLink>
                </nav>
            </div>

            <div className="header-right">
                <div className="notification-btn">
                    🔔 
                    <span className="badge">3</span>
                </div>
                                
                <div className="user-profile">
                    <div className="avatar">GA</div>
                    <span className="username">Garson Ali</span>
                </div>
            </div>
        </div>
    )
}

export default Header;