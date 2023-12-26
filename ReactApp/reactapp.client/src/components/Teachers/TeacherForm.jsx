import { useState } from 'react'
import Input from '../UI/input/Input'
import Button from '../UI/button/Button'

const TeacherForm = ({ create }) => {
   const [teacher, setTeacher] = useState({
      lastName: '',
      firstName: '',
      experience: '',
   })

   const createNewTeacher = (e) => {
      e.preventDefault()
      create(teacher)
   }

   return (
      <form>
         <Input
            placeholder='Фамилия'
            value={teacher.lastName}
            onChange={(e) => setTeacher({ ...teacher, lastName: e.target.value })}
         />

         <Input
            placeholder='Имя'
            value={teacher.firstName}
            onChange={(e) => setTeacher({ ...teacher, firstName: e.target.value })}
         />

         <Input
            value={teacher.email}
            placeholder='Стаж'
            onChange={(e) => setTeacher({ ...teacher, experience: e.target.value })}
         />

         <Button onClick={createNewTeacher}>Добавить</Button>
      </form>
   )
}

export default TeacherForm
