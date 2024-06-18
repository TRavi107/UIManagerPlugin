using DG.Tweening;
using System;
using UnityEngine;

namespace UIManagement
{
    /// <summary>
    /// Base class for all the different types of animated UI panel
    /// </summary>
    public abstract class AUIAnimatedPanel : MonoBehaviour
    {
        [SerializeField] protected float openDuration=0.5f;
        [SerializeField] protected float closeDuration=0.5f;
        [SerializeField] protected Ease openEase;
        [SerializeField] protected Ease closeEase;

        public event Action<AUIAnimatedPanel> OnPanelOpenStarted;
        public event Action<AUIAnimatedPanel> OnPanelOpened;
        public event Action<AUIAnimatedPanel> OnPanelCloseStarted;
        public event Action<AUIAnimatedPanel> OnPanelClosed;

        public abstract void OpenPanel();

        public abstract void ClosePanel(bool instantClose);

        public void InvokeOnPanelOpenStarted() => OnPanelOpenStarted?.Invoke(this);
        public void InvokeOnPanelOpened() => OnPanelOpened?.Invoke(this);
        public void InvokeOnPanelCloseStarted() => OnPanelCloseStarted?.Invoke(this);
        public void InvokeOnPanelClosed() => OnPanelClosed?.Invoke(this);
    }
}
