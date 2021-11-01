using UnityEngine;


namespace Platformer2D
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}
