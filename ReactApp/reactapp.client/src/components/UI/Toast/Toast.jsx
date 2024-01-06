import React from 'react'

const Toast = () => {
   return (
      <div
         className='toast show align-items-center'
         role='alert'
         aria-live='assertive'
         aria-atomic='true'
      >
         <div className='d-flex'>
            <div className='toast-body'>Преподаватель успешно добавлен!</div>
            <button
               type='button'
               className='btn-close me-2 m-auto'
               data-bs-dismiss='toast'
               aria-label='Close'
            ></button>
         </div>
      </div>
   )
}

export default Toast
