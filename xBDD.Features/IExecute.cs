using System.Threading.Tasks;

namespace xBDD.Features
{
    public interface IExecute<TResult>
    {
        Task<TResult> Execute();
    }
}
