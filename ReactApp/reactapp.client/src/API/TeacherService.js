import axios from 'axios'

export default class TeacherService {
   static baseUrl = 'https://localhost:7117'

   static config = {
      headers: {
         'Content-Type': 'application/json',
      },
   }

   static axios = axios.create({
      baseURL: this.baseUrl,
      headers: this.config.headers,
   })

   static async getAll() {
      const response = await this.axios.get('/Teacher/GetAll')
      return response.data
   }

   static async addTeacher(newTeacher) {
      const response = await this.axios.post('/Teacher/CreateTeacher', newTeacher)
      return response.data
   }

   static async deleteTeacher(teacherId) {
      const response = await this.axios.delete(`Teacher/Delete/${teacherId}`)
      return response.data
   }
}
