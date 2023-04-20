using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Sql.Repositories
{
    public interface IWikiBaaCommentRepository : IBaseRepository<WikiBlockComment>
    {
        public IEnumerable<WikiBlockComment> GetComments();
    }
}