using System;


namespace Platformer2D
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}
