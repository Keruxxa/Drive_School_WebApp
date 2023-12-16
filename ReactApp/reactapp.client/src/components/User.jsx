import React from 'react'

const User = ({ user }) => {

   return (
      <tr key={user.id}>
         <td>{user.id}</td>
         <td>{user.lastName}</td>
         <td>{user.firstName}</td>
         <td>{user.email}</td>
         <button className='btn btn-primary' style={{ marginLeft: 10 }}>Удалить</button>
      </tr >
   )
}

export default User
