using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Fake.Repositories
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : IDbModel
    {
        public List<DbModel> FakeDbModels = new List<DbModel>();
                
        public void Add(DbModel model)
        {
            var maxExistedId = FakeDbModels.Max(x => x.Id);
            model.Id = maxExistedId + 1;
            FakeDbModels.Add(model);
        }

        public IEnumerable<DbModel> GetAll()
        {
            return FakeDbModels;
        }

        public DbModel Get(int id)
        {
            return FakeDbModels.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            FakeDbModels.Remove(Get(id));
        }
    }
}
