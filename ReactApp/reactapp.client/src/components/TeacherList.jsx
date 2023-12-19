import Teacher from './Teacher'

const TeacherList = ({ teachers }) => {
   return (
      <div>
         <h1 style={{ textAlign: 'center' }}>Список преподавателей</h1>
         <table className="table table-striped" aria-labelledby="tabelLabel">
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
