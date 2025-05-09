import { createRoot } from 'react-dom/client'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import './index.css'
import Home from './pages/Home'
import Login from './pages/Login'
import Register from './pages/Register'

createRoot(document.getElementById('root')).render(

  <div className='flex flex-col items-center justify-center min-h-screen bg-blue-50 p-8'>
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </Router>
  </div>
)
