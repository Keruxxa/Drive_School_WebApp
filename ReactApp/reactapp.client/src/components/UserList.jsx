/* eslint-disable no-unused-vars */
/* eslint-disable react/prop-types */

import React from 'react'
import User from './User'

const UserList = ({ users }) => {
   return (
      <div>
         <h1 style={{ textAlign: 'center' }}>
            Список пользоваетелей
         </h1>
         <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
               <tr>
                  <th>ID</th>
                  <th>Last name</th>
                  <th>First name</th>
                  <th>Email</th>
               </tr>
            </thead>
            <tbody>
               {
                  users.map(user =>
                     <User user={user} key={user.id} />)
               }
            </tbody>
         </table>
      </div>
   )
}

export default UserList
