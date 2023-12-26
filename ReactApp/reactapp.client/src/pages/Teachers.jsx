import axios from 'axios'
import { useEffect, useState } from 'react'
import TeachersList from '../components/Teachers/TeacherList'
import Loading from '../components/UI/Loading/Loading'

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

   return (
      <div>
         <h1 style={{ textAlign: 'center' }}>Список преподавателей</h1>
         {isTeachersLoading ? (
            <Loading />
         ) : teachers.length ? (
            <TeachersList teachers={teachers} />
         ) : (
            <h1 style={{ textAlign: 'center' }}>Список преподавателей пуст</h1>
         )}
      </div>
   )
}

export default Teachers
