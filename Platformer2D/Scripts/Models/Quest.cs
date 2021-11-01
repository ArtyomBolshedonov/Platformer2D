using System;


namespace Platformer2D
{
    internal sealed class Quest : IQuest
    {
        private readonly LeverObjectView _leverObjectView;
        private readonly IQuestModel _model;

        private bool _active;

        public Quest(LeverObjectView leverObjectView, IQuestModel model)
        {
            _leverObjectView = leverObjectView != null ? leverObjectView : throw new ArgumentNullException(nameof(leverObjectView));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        private void OnContact(ObjectView arg2)
        {
            var completed = _model.TryComplete(arg2.gameObject);
            if (completed) Complete();
        }

        private void Complete()
        {
            if (!_active) return;
            _active = false;
            IsCompleted = true;
            _leverObjectView.OnObjectContact -= OnContact;
            _leverObjectView.ProcessComplete();
            OnCompleted();
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        public void Reset()
        {
            if (_active) return;
            _active = true;
            IsCompleted = false;
            _leverObjectView.OnObjectContact += OnContact;
            _leverObjectView.ProcessActivate();
        }

        public void Dispose()
        {
            _leverObjectView.OnObjectContact -= OnContact;
        }
    }
}

