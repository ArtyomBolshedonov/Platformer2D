using UnityEngine;


namespace Platformer2D
{
    internal sealed class SwitchQuestModel : IQuestModel
    {
        private const string TargetTag = "Player";
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}
