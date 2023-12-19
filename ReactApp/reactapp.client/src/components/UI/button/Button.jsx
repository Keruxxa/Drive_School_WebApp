import classes from './Button.module.css'

const Button = ({ children, ...props }) => {
   return (
      <button {...props} className={`btn btn-primary ${classes.btnPrimaryMarged}`}>
         {children}
      </button>
   )
}

export default Button
