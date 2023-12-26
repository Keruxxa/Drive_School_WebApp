import { useState } from 'react'
import Input from '../input/Input'

const ModalWindow = () => {
   const [teacher, setTeacher] = useState({ lastName: '', firstName: '', experience: '' })

   return (
      <div className='modal fade' id='modal' tabIndex='-1' aria-hidden='true'>
         <div className='modal-dialog modal-lg modal-dialog-centered'>
            <div className='modal-header'>
               <h5 className='modal-title'>Добавление преподавателя</h5>
               <button
                  type='button'
                  className='btn-close'
                  data-bs-dismiss='modal'
                  aria-label='Close'
               ></button>
            </div>

            <div className='modal-body'>
               <div className='input-group mb-3'>
                  <span className='input-group-text'>Фамилия</span>
                  <Input
                     placeholder='Фамилия'
                     value={teacher.lastName}
                     onChange={(e) =>
                        setTeacher({ ...teacher, lastName: e.target.value })
                     }
                  />
               </div>
               <div className='input-group mb-3'>
                  <span className='input-group-text'>Имя</span>
                  <Input
                     placeholder='Имя'
                     value={teacher.firstName}
                     onChange={(e) =>
                        setTeacher({ ...teacher, firstName: e.target.value })
                     }
                  />
               </div>
               <div className='input-group mb-3'>
                  <span className='input-group-text'>Опыт</span>
                  <Input
                     value={teacher.email}
                     placeholder='Стаж'
                     onChange={(e) =>
                        setTeacher({ ...teacher, experience: e.target.value })
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
