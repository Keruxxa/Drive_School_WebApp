import axios from "axios"

export default class TeacherService {
   static baseUrl = 'https://localhost:7117'

   static config = {
      headers: {
         'Content-Type': 'application/json'
      }
   }
   static async getAll() {
      const response = await axios.get(`${this.baseUrl}/Teacher/GetAll`)
      return response.data
   }

   static async addTeacher(newTeacher) {
      const respone = await axios.post(`${this.baseUrl}/Teacher/CreateTeacher`, newTeacher, this.config)
      return respone.data
   }
}