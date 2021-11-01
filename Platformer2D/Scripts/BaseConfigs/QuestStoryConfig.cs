using UnityEngine;


namespace Platformer2D
{
    [CreateAssetMenu(menuName = "QuestStoryConfig", fileName = "QuestStoryConfig", order = 0)]
    internal class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }

}
