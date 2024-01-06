/* eslint-disable react-hooks/exhaustive-deps */

import { useEffect, useState } from 'react'
import Input from '../Input/Input'
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'
import Delay from '../../../API/Delay'
import ValidationAlert from '../Alert/ValidationAlert'

const TeacherModal = ({
   isOpen,
   toggle,
   modalTitle,
   teacherToUpdate,
   createTeacher,
}) => {
   const [teacher, setTeacher] = useState({
      lastName: '',
      firstName: '',
      experience: 0,
   })

   const [validationError, setValidationError] = useState(false)

   const [errorMessage, setErrorMessage] = useState('')

   const validate = () => {
      switch (true) {
         case teacher.lastName === '':
            setErrorMessage('Поле с фамилией не может быть пустым!')
            return false
         case teacher.firstName === '':
            setErrorMessage('Поле с именем не может быть пустым!')
            return false
         case teacher.experience < 5:
            setErrorMessage('Стаж преподавателя не может быть меньше 5 лет!')
            return false
         default:
            return true
      }
   }

   const createNewTeacher = async () => {
      if (!validate()) {
         setValidationError(true)
         return false
      }

      toggle()

      await Delay.delayedTask(200)

      const newTeacher = {
         lastName: teacher.lastName,
         firstName: teacher.firstName,
         experience: teacher.experience,
      }
      createTeacher(newTeacher)

      setValidationError(false)
   }

   const handleValidationAlertClick = () => {
      setValidationError(false)
   }

   useEffect(() => {
      setTeacher({
         lastname: '',
         firstName: '',
         experience: 0,
      })

      console.log(teacher)

      setValidationError(false)
   }, [isOpen])

   return (
      <Modal className='modal-dialog-centered' isOpen={isOpen}>
         <ModalHeader>{modalTitle}</ModalHeader>

         <ModalBody>
            <div className='input-group mb-3'>
               <span className='input-group-text' style={{ width: 90 }}>
                  Фамилия
               </span>
               <Input
                  required
                  placeholder='Иванов'
                  value={teacher.lastName}
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
                  required
                  placeholder='Иван'
                  value={teacher.firstName}
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
                  Стаж
               </span>
               <Input
                  required
                  type='number'
                  min='0'
                  value={teacher.experience}
                  onChange={(e) =>
                     setTeacher({
                        ...teacher,
                        experience: e.target.value,
                     })
                  }
               />
            </div>
            {validationError && (
               <div>
                  <ValidationAlert
                     errorMessage={errorMessage}
                     closeValidationAlert={handleValidationAlertClick}
                  />
               </div>
            )}
         </ModalBody>
         <ModalFooter>
            <button className='btn btn-primary' onClick={createNewTeacher}>
               Подтвердить
            </button>

            <button className='btn btn-secondary' onClick={() => toggle(modalTitle)}>
               Закрыть
            </button>
         </ModalFooter>
      </Modal>
   )
}

export default TeacherModal
