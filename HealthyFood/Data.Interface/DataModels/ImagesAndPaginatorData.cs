using Data.Interface.Models;

namespace Data.Interface.DataModels
{
    public class ImagesAndPaginatorData
    {
        public List<ImagesAndInfoAboutTheirUploaderData> Images { get; set; }
        public int TotalCount { get; set; }
    }
}
