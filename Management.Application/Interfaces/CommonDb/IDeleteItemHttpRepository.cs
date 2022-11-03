using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IDeleteItemHttpRepository
    {
        Task<string> DeleteAccItem(int itemId);
    }
}