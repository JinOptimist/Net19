using Data.Interface.Models;

namespace Data.Sql.Models
{
    public class BlockModelBAA : BaseDbModel, IBlockModelBAA
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
