import { useEffect, useState } from 'react'
import Input from '../Input/Input'
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'

const AddTeacherModal = ({ toggle, create, isOpen }) => {
   const [teacher, setTeacher] = useState({
      lastName: '',
      firstName: '',
      experience: 0,
   })

   const createNewTeacher = () => {
      const newTeacher = { teacher }
      create(newTeacher)
   }

   useEffect(() => {
      const handleBeforeUnload = (prevTeacherInfo) => {
         setTeacher({
            ...prevTeacherInfo,
            lastName: '',
            firstName: '',
            experience: 0,
         })
      }

      window.addEventListener('beforeunload', handleBeforeUnload)

      return () => {
         window.removeEventListener('beforeunload', handleBeforeUnload)
      }
   }, [])

   return (
      <Modal className='modal-dialog-centered' isOpen={isOpen}>
         <ModalHeader>Добавление преподавателя</ModalHeader>

         <ModalBody>
            <div className='input-group mb-3'>
               <span className='input-group-text' style={{ width: 90 }}>
                  Фамилия
               </span>
               <Input
                  placeholder='Иванов'
                  onChange={(e) =>
                     setTeacher({
                        ...teacher,
                        lastName: e.target.value,
                     })
                  }
               />
            </div>
            <div className='input-group mb-3'>
               <span className='input-group-text' style={{ width: 90 }}>
                  Имя
               </span>
               <Input
                  placeholder='Иван'
                  onChange={(e) =>
                     setTeacher({
                        ...teacher,
                        firstName: e.target.value,
                     })
                  }
               />
            </div>
            <div className='input-group mb-3'>
               <span className='input-group-text' style={{ width: 90 }}>
                  Возраст
               </span>
               <Input
                  type='number'
                  min='0'
                  onChange={(e) =>
                     setTeacher({
                        ...teacher,
                        experience: e.target.value,
                     })
                  }
               />
            </div>
         </ModalBody>
         <ModalFooter>
            <button className='btn btn-primary' onClick={createNewTeacher}>
               Подтвердить
            </button>

            <button className='btn btn-secondary' onClick={toggle}>
               Закрыть
            </button>
         </ModalFooter>
      </Modal>
   )
}

export default AddTeacherModal
