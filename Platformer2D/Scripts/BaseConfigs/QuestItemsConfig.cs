using UnityEngine;
using System.Collections.Generic;


namespace Platformer2D
{
    [CreateAssetMenu(menuName = "QuestItemsConfig", fileName = "QuestItemsConfig", order = 0)]
    internal class QuestItemsConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemIdCollection;
    }
}

