import { useState } from 'react'
import Input from '../Input/Input'

const ModalWindow = () => {
   const [teacherInfo, setTeacherInfo] = useState({
      lastName: '',
      firstName: '',
      experience: '',
   })

   return (
      <div className='modal fade' id='windowModal' aria-hidden='true'>
         <div className='modal-dialog modal-lg modal-dialog-centered'>
            <div className='modal-content'>
               <div className='modal-header'>
                  <h5 className='modal-title'>Добавление преподавателя</h5>
                  <button
                     type='button'
                     className='btn-close'
                     data-bs-dismiss='modal'
                     aria-label='Close'
                  ></button>
               </div>
            </div>

            <div className='modal-body'>
               <div className='input-group mb-3'>
                  <span className='input-group-text'>Фамилия</span>
                  <Input
                     placeholder='Иванов'
                     value={teacherInfo.lastName}
                     onChange={(e) =>
                        setTeacherInfo({
                           ...teacherInfo,
                           lastName: e.target.value,
                        })
                     }
                  />
               </div>
               <div className='input-group mb-3'>
                  <span className='input-group-text'>Имя</span>
                  <Input
                     placeholder='Иван'
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
                  <span className='input-group-text'>Опыт</span>
                  <Input
                     value={teacherInfo.experience}
                     placeholder='Стаж'
                     style={{ maxWidth: 100 }}
                     onChange={(e) =>
                        setTeacherInfo({
                           ...teacherInfo,
                           experience: e.target.value,
                        })
                     }
                  />
               </div>
               <button className='btn btn-primaty float-start'>Добавить</button>
            </div>
         </div>
      </div>
   )
}

export default ModalWindow
