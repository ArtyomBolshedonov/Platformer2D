namespace Platformer2D
{
    internal sealed class SingleQuestController
    {
        private readonly LeverObjectView _leverObjectView;
        private Quest _singleQuest;

        public Quest Quest => _singleQuest;

        public SingleQuestController(LeverObjectView leverObjectView)
        {
            _leverObjectView = leverObjectView;
            _singleQuest = new Quest(_leverObjectView, new SwitchQuestModel());
        }

        public void StartQuest()
        {
            _singleQuest.Reset();
        }
    }
}
