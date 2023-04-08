

using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IQuizRepository
    {
        //int GetQuantityWinner();
        //int GetQuantityPlayers();
        //int GetQuantityСorrect_answer();
        IEnumerable<Quiz> GetInfoAboitQuizGamed();
    }
}
