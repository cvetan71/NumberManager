namespace NumberManager.Models
{
    public class NumberListModel
    {
        public List<int> Numbers { get; set; } = new();
        public int Count => Numbers?.Count ?? 0;
        public int? Sum { get; set; }
    }

}
