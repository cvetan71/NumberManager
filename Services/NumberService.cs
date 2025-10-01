using NumberManager.Models;
using System.Text.Json;

namespace NumberManager.Services
{
    public class NumberService : INumberService
    {
        private const string SessionKey = "NumberListSession";

        private readonly IHttpContextAccessor _context;

        public NumberService(IHttpContextAccessor context) => _context = context;

        public NumberListModel GetList()
        {
            var session = _context.HttpContext?.Session;
            if (session == null)
                return new NumberListModel();

            var value = session.GetString(SessionKey);
            if (string.IsNullOrEmpty(value))
                return new NumberListModel();

            return JsonSerializer.Deserialize<NumberListModel>(value) ?? new NumberListModel();
        }

        public void AddRandom()
        {
            var list = GetList();
            list.Numbers.Add(new Random().Next(100, 999));
            Save(list);
        }

        public void Clear() => Save(new NumberListModel());

        public void Sum()
        {
            var list = GetList();
            list.Sum = list.Numbers.Sum();
            Save(list);
        }

        private void Save(NumberListModel model)
        {
            var session = _context.HttpContext?.Session;
            if (session == null)
                return;

            var value = JsonSerializer.Serialize(model);
            session.SetString(SessionKey, value);
        }
    }
}
