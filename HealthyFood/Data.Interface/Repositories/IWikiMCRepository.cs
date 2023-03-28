using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiMCRepository
    {
        IWikiMCModel GetImgByYear(int year);
        IWikiMCModel GetImgByType(string type);
        List<IWikiMCModel> GetAll();
        void SaveImg(IWikiMCModel img);
        void RemoveByYear(int year);
        void RemoveByType(string type);
    }
}
