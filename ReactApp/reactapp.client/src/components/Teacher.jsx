const Teacher = ({ teacher }) => {
   return (
      <tr key={teacher.id}>
         <td>{teacher.lastName}</td>
         <td>{teacher.firstName}</td>
         <td>{teacher.experience}</td>
         <button className="btn btn-primary" style={{ marginLeft: 10 }}>
            Удалить
         </button>
      </tr>
   )
}

export default Teacher
