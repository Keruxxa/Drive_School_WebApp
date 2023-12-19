import { Route, Routes } from 'react-router-dom'
import { Navigate } from 'react-router-dom'
import About from '../pages/About'
import Teachers from '../pages/Teachers'
import Groups from '../pages/Groups'
import Home from '../pages/Home'

const AppRoutes = () => {
   return (
      <Routes>
         <Route path="" element={<Navigate to="/home" />} />
         <Route path="/home" element={<Home />} />
         <Route path="/teachers" element={<Teachers />} />
         <Route path="/groups" element={<Groups />} />
         <Route path="/about" element={<About />} />
      </Routes>
   )
}

export default AppRoutes
