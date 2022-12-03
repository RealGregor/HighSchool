using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMA.Data.Contracts.Writers
{
    public interface IWriter<IModel> where IModel : class
    {
        Task<int> Create(IModel model);
        Task<long> Update(IModel model);
        Task<long> Delete(Guid id);
    }
}
