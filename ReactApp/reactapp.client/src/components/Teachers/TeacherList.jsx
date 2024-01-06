import Teacher from './Teacher'
import { useState } from 'react'
import TeacherModal from '../UI/ModalWindows/TeacherModal'
import TeacherService from '../../API/TeacherService'
import Delay from '../../API/Delay'

const TeacherList = ({ teachers, addTeacher, refreshTeachers }) => {
   const [modalIsOpen, setModalIsOpen] = useState(false)
   const [modalTitle, setModalTitle] = useState('')
   const [teacherToUpdate, setTeacherToUpdate] = useState({
      lastName: '',
      firstName: '',
      experience: 0,
   })

   const toggleModal = () => {
      setModalIsOpen(!modalIsOpen)
   }

   const handleCreateTeacher = (newTeacher) => {
      addTeacher(newTeacher)
   }

   const openModalAddTeacher = () => {
      setModalTitle('Добавление преподавателя')
      toggleModal()
   }

   const handleUpdateTeacher = async (teacher) => {
      setModalTitle('Изменение преподавателя')
      setTeacherToUpdate(teacher)
      toggleModal()
   }

   const handleDeleteTeacher = async (teacherId) => {
      const result = confirm('Удалить преподавателя?')
      if (result) {
         console.log(teacherId)
         const result = TeacherService.deleteTeacher(teacherId)
         console.log(result)
         await Delay.delay(100)
         await refreshTeachers()
      }
   }

   return (
      <div>
         <button
            className='btn btn-primary m-2 float-end'
            onClick={openModalAddTeacher}
         >
            Добавить преподавателя
         </button>

         <TeacherModal
            isOpen={modalIsOpen}
            toggle={toggleModal}
            modalTitle={modalTitle}
            createTeacher={handleCreateTeacher}
            teacherToUpdate={teacherToUpdate}
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
                  <Teacher
                     teacher={teacher}
                     key={teacher.id}
                     update={handleUpdateTeacher}
                     deleteTeacher={handleDeleteTeacher}
                  />
               ))}
            </tbody>
         </table>
      </div>
   )
}

export default TeacherList
