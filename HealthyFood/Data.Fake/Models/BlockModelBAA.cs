using Data.Interface.Models;

namespace Data.Fake.Models
{
    public class BlockModelBAA : BaseDbModel, IBlockModelBAA
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
