/* eslint-disable react/prop-types */
import { useState } from 'react'
import React from 'react'
import Input from './UI/input/Input'
import Button from './UI/button/Button'

const UserForm = ({ create }) => {

   const [user, setUser] = useState({ lastName: '', firstName: '', email: '' })

   const createNewUser = (e) => {
      e.preventDefault()
      create(user)
   }

   return (
      <form>
         <Input
            placeholder="Фамилия"
            value={user.lastName}
            onChange={(e) => setUser({ ...user, lastName: e.target.value })} />

         <Input
            placeholder="Имя"
            value={user.firstName}
            onChange={(e) => setUser({ ...user, firstName: e.target.value })} />


         <Input
            value={user.email}
            placeholder="e-mail"
            onChange={(e) => setUser({ ...user, email: e.target.value })} />

         <Button onClick={createNewUser}>Добавить</Button>
      </form>
   )
}

export default UserForm
