using UnityEngine;


namespace Platformer2D
{
    [CreateAssetMenu(menuName = "Create QuestConfig", fileName = "QuestConfig", order = 0)]
    internal class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }
}
