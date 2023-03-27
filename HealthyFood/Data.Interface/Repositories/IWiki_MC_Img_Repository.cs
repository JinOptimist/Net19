using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWiki_MC_Img_Repository
    {
        IWiki_MC_Img_Model GetImgByYear(int year);
        IWiki_MC_Img_Model GetImgByType(string type);
        List<IWiki_MC_Img_Model> GetAll();
        void SaveImg(IWiki_MC_Img_Model img);
        void RemoveByYear(int year);
        void RemoveByType(string type);
    }
}
