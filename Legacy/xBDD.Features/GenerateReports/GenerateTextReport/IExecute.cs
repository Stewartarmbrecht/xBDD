using System.Threading.Tasks;

namespace xBDD.Features.GenerateReports.GenerateTextReport
{
    public interface IExecute<TResult>
    {
        Task<TResult> Execute();
    }
}
