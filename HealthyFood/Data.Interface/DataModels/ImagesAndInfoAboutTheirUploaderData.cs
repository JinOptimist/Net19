using Data.Interface.Models;

namespace Data.Interface.DataModels
{
    public class ImagesAndInfoAboutTheirUploaderData
    {
        public int Year { get; set; }

        public string ImgUrl { get; set; }

        public ImgTypeEnum ImgType { get; set; }

        public List<string> Tags { get; set; }

        public string UserName { get; set; }
    }
}
