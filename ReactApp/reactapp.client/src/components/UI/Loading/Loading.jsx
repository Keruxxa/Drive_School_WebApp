import React from 'react'

const Loading = () => {
   return (
      <div className='container'>
         <div className='d-flex align-items-center'>
            <strong role='status'>Загрузка... Пожалуйста, подождите</strong>
            <div className='spinner-border ms-auto' aria-hidden='true'></div>
         </div>
      </div>
   )
}

export default Loading
