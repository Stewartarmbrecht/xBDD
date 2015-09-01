using System;

namespace xBDD
{
    public interface IStep
    {
        Action<IStep> Action { get; set; }
        ActionType ActionType { get; set; }
        string Name { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }

    }
}
