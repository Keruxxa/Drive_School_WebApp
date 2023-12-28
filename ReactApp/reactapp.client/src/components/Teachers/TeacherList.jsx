import Teacher from './Teacher'
import { useState } from 'react'
import AddTeacherModal from '../UI/ModalWindows/TeacherModal'

const TeacherList = ({ teachers, addTeacher }) => {
   const [modalIsOpen, setModalIsOpen] = useState(false)
   const [modalTitle, setModalTitle] = useState('')

   const toggleModal = () => {
      setModalTitle('Добавление преподавателя')
      setModalIsOpen(!modalIsOpen)
   }

   const createTeacher = (newTeacher) => {
      addTeacher(newTeacher)
   }

   return (
      <div>
         <button className='btn btn-primary m-2 float-end' onClick={toggleModal}>
            Добавить преподавателя
         </button>

         <AddTeacherModal
            isOpen={modalIsOpen}
            toggle={toggleModal}
            createTeacher={createTeacher}
            modalTitle={modalTitle}
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
