const ValidationAlert = ({ errorMessage, closeValidationAlert }) => {
   return (
      <div className='alert alert-dismissible alert-danger'>
         <button
            type='button'
            className='btn-close'
            data-bs-dismiss='alert'
            onClick={closeValidationAlert}
         ></button>
         <strong>{errorMessage}</strong>
      </div>
   )
}

export default ValidationAlert
