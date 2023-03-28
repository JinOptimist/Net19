namespace Data.Interface.Models
{
    public interface IWikiMCModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
    }
}
