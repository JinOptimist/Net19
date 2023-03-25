using HealthyFoodWeb.Services.FakeDb;

namespace HealthyFoodWeb.Services.WikiServices
{
    public class BlockInformationServices : IBlockInformationServices
    {
        private WikiRepositoryBAA _wikiRepositoryBAA;

        public BlockInformationServices(WikiRepositoryBAA wikiRepositoryBAA)
        {
            _wikiRepositoryBAA = wikiRepositoryBAA;
        }

        public string BlockInformation()
        {
            return _wikiRepositoryBAA.GetTitle().First();
        }

    }
}
