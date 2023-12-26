import axios from 'axios'
import { useEffect, useState } from 'react'
import TeacherForm from '../components/TeacherForm'
import TeachersList from '../components/TeacherList'

const Teachers = () => {
   const [teachers, setTeachers] = useState([])
   const [isTeachersLoading, setIsTeachersLoading] = useState(false)

   const API_URL = 'https://localhost:7117'

   const fetchTeachers = async () => {
      setIsTeachersLoading(true)
      const response = await axios.get(API_URL + '/Teacher/GetAll')
      setTeachers(response.data)
      setIsTeachersLoading(false)
   }

   useEffect(() => {
      fetchTeachers()
   }, [])

   const addNewTeacher = (newTeacher) => {
      setTeachers([...teachers, newTeacher])
   }

   const addClick = () => {}

   return (
      <div>
         {teachers.length ? (
            <TeachersList teachers={teachers} />
         ) : (
            <h1 style={{ textAlign: 'center' }}>Список преподавателей пуст</h1>
         )}
      </div>
   )
}

export default Teachers
