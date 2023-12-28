export default class Delay {
   static delay = (ms) => {
      return new Promise((resolve) => setTimeout(resolve, ms))
   }

   static delayedTask = async (ms) => {
      await this.delay(ms) // Задержка на 2 секунды
   }
}