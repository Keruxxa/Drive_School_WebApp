import classes from './Input.module.css'

const Input = (props) => {
   return (
      <input {...props} className={`form-control ${classes.formControlChanged}`} />
   )
}

export default Input
