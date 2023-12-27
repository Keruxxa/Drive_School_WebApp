import Teacher from './Teacher'
import { useState } from 'react'
import Input from '../UI/input/Input'
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap'

const TeacherList = ({ teachers }) => {
   const [teacherInfo, setTeacherInfo] = useState({
      lastName: '',
      firstName: '',
      experience: 0,
   })

   const [isOpen, setIsOpen] = useState(false)

   const toggleModal = () => {
      setIsOpen(!isOpen)
      setTeacherInfo((prevTeacherInfo) => ({
         ...prevTeacherInfo,
         lastName: '',
         firstName: '',
         experience: 0,
      }))
   }

   return (
      <div>
         <button className='btn btn-primary m-2 float-end' onClick={toggleModal}>
            Добавить преподавателя
         </button>

         {/* Модальное окно */}
         <Modal
            className='modal-dialog-centered'
            isOpen={isOpen}
            toggle={toggleModal}
         >
            <ModalHeader>Добавление преподавателя</ModalHeader>

            <ModalBody>
               <div className='input-group mb-3'>
                  <span className='input-group-text' style={{ width: 90 }}>
                     Фамилия
                  </span>
                  <Input
                     onChange={(e) =>
                        setTeacherInfo({
                           ...teacherInfo,
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
                     value={teacherInfo.firstName}
                     onChange={(e) =>
                        setTeacherInfo({
                           ...teacherInfo,
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
                     value={teacherInfo.experience}
                     onChange={(e) =>
                        setTeacherInfo({
                           ...teacherInfo,
                           experience: e.target.value,
                        })
                     }
                  />
               </div>
            </ModalBody>
            <ModalFooter>
               <button className='btn btn-primary'>Подтвердить</button>

               <button className='btn btn-secondary' onClick={() => toggleModal()}>
                  Закрыть
               </button>
            </ModalFooter>
         </Modal>
         {/* Модальное окно */}

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
