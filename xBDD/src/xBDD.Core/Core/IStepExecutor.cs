using System.Threading.Tasks;

namespace xBDD.Core
{
    public interface IStepExecutor
    {
        void ExecuteStep(IStep step);
        Task ExecuteStepAsync(IStep step);
        void SetEndTimes(IStep step);
    }
}