import { Component, useEffect, useState } from 'react'
import axios from 'axios'
import UserList from './components/UserList'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import UserForm from './components/UserForm'

function App() {
   const [users, setUsers] = useState([])
   const [isUsersLoading, setIsUsersLoading] = useState(false)

   const API_URL = 'https://localhost:7117'

   async function fetchUsers() {
      setIsUsersLoading(true)
      const response = await axios.get(API_URL + '/User/GetAll')
      setUsers(response.data)
      setIsUsersLoading(false)
   }

   useEffect(() => {
      fetchUsers()
   }, [])

   const addNewUser = (newUser) => {
      setUsers([...users, newUser])
   }

   return (
      <div className="container">
         <UserForm create={addNewUser} />
         {
            users.length
               ?
               <UserList users={users} />

               :
               <h1 style={{ textAlign: 'center' }}>
                  Список пользоваетелей пуст
               </h1>
         }
      </div>
   )
}

export default App
