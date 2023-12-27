import Teacher from './Teacher'
import { useState } from 'react'
import AddTeacherModal from '../UI/ModalWindows/AddTeacherModal'

const TeacherList = ({ teachers }) => {
   const [modalIsOpen, setModalIsOpen] = useState(false)

   const toggleModal = () => {
      setModalIsOpen(!modalIsOpen)
   }

   const createTeacher = (teacher) => {
      console.log(teacher)
   }

   return (
      <div>
         <button className='btn btn-primary m-2 float-end' onClick={toggleModal}>
            Добавить преподавателя
         </button>

         <AddTeacherModal
            isOpen={modalIsOpen}
            toggle={toggleModal}
            create={createTeacher}
         />

         <table className='table table-striped'>
            <thead>
               <tr>
                  <th>Фамилия</th>
                  <th>Имя</th>
                  <th>Стаж</th>
               </tr>
            </thead>
            <tbody>
               {teachers.map((teacher) => (
                  <Teacher teacher={teacher} key={teacher.id} />
               ))}
            </tbody>
         </table>
      </div>
   )
}

export default TeacherList
