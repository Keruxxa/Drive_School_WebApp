using API.Server.Models;

namespace API.Server.Interfaces
{
    public interface ICarRepository
    {
        Task<ICollection<Car>> GetCarsAsync();

        Task<Car> GetCarByIdAsync(int carId);

        Task<bool> CarExistsAsync(int carId);

        Task<bool> AddCarAsync(Car car);

        Task<bool> UpdateCarAsync(Car car);

        Task<bool> DeleteCarAsync(Car car);

        Task<bool> SaveAsync();
    }
}
