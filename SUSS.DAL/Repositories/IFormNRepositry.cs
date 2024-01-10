using SUSS.DOM.Entities;

namespace SUSS.DAL.Repositories
{
    public interface IFormNRepositry
    {
        Task<int> CreateFormN(FormN formN_data);
    }
}
