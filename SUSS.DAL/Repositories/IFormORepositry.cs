using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface IFormORepositry
    {
        Task<int> CreateFormO(FormO formO_data);
    }
}
