using NumberManager.Models;

namespace NumberManager.Services
{
    public interface INumberService
    {
        NumberListModel GetList();
        void AddRandom();
        void Clear();
        void Sum();
    }
}
