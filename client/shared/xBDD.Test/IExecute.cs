using System.Threading.Tasks;

namespace xBDD.Test
{
    public interface IExecute<TResult>
    {
        Task<TResult> Execute();
    }
}
