import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import { BrowserRouter, Link } from 'react-router-dom'
import AppRoutes from './components/AppRoutes'

function App() {
   return (
      <BrowserRouter>
         <nav className="navbar navbar-expand-lg bg-primary" data-bs-theme="dark">
            <div className="container-fluid">
               <button
                  className="navbar-toggler"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#navbarColor01"
                  aria-controls="navbarColor01"
                  aria-expanded="false"
                  aria-label="Toggle navigation"
               >
                  <span className="navbar-toggler-icon"></span>
               </button>
               <div className="container">
                  <div className="collapse navbar-collapse" id="navbarColor01">
                     <ul className="navbar-nav me-auto">
                        <li className="nav-item">
                           <Link className="nav-link" to="/home">
                              Главная
                              <span className="visually-hidden">(current)</span>
                           </Link>
                        </li>
                        <li className="nav-item">
                           <Link className="nav-link" to="/teachers">
                              Преподаватели
                           </Link>
                        </li>
                        <li className="nav-item">
                           <Link className="nav-link" to="/groups">
                              Группы
                           </Link>
                        </li>
                        <li className="nav-item">
                           <Link className="nav-link" to="/about">
                              Справка
                           </Link>
                        </li>
                     </ul>
                  </div>
               </div>
            </div>
         </nav>

         <div className="container">
            <AppRoutes />
         </div>
      </BrowserRouter>
   )
}

export default App
