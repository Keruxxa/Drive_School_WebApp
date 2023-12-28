/* eslint-disable react-hooks/exhaustive-deps */

import { useEffect, useState } from 'react'
import Input from '../Input/Input'
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'
import Delay from '../../../API/Delay'

const AddTeacherModal = ({ toggle, createTeacher, isOpen, modalTitle }) => {
   const [teacher, setTeacher] = useState({
      lastName: '',
      firstName: '',
      experience: 0,
   })

   const createNewTeacher = async () => {
      toggle()

      await Delay.delayedTask(200)

      const newTeacher = {
         lastName: teacher.lastName,
         firstName: teacher.firstName,
         experience: teacher.experience,
      }
      createTeacher(newTeacher)
   }

   useEffect(() => {
      setTeacher({
         lastName: '',
         firstName: '',
         experience: 0,
      })
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
                  Стаж
               </span>
               <Input
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
