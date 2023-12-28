import { useEffect, useState } from 'react'
import TeachersList from '../components/Teachers/TeacherList'
import Loading from '../components/UI/Loading/Loading'
import TeacherService from '../API/TeacherService'

const Teachers = () => {
   const [teachers, setTeachers] = useState([])
   const [isTeachersLoading, setIsTeachersLoading] = useState(false)

   const fetchTeachers = async () => {
      setIsTeachersLoading(true)
      const teachers = await TeacherService.getAll()
      setTeachers(teachers)
      setIsTeachersLoading(false)
   }

   const refreshTeachers = async () => {
      await fetchTeachers()
   }

   const addTeacher = async (newTeacher) => {
      const result = await TeacherService.addTeacher(newTeacher)
      console.log(result)
      refreshTeachers()
   }

   useEffect(() => {
      fetchTeachers()
   }, [])

   return (
      <div>
         <h1 style={{ textAlign: 'center' }}>Список преподавателей</h1>
         {isTeachersLoading ? (
            <Loading />
         ) : teachers.length ? (
            <TeachersList teachers={teachers} addTeacher={addTeacher} />
         ) : (
            <h1 style={{ textAlign: 'center' }}>Список преподавателей пуст</h1>
         )}
      </div>
   )
}

export default Teachers
