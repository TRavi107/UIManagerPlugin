using UnityEngine;
using DG.Tweening;

namespace UIManagement
{
    /// <summary>
    /// This animated panel inherits AUIAnimatedPanel 
    /// This class fades in or fades out the panel
    /// </summary>
    /// 
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeUIAnimatedPanel : AUIAnimatedPanel
    {
        private CanvasGroup m_CanvasGroup;
        private void Start()
        {
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }
        public override void ClosePanel(bool instantClose)
        {
            InvokeOnPanelCloseStarted();
            if (instantClose)
            {
                m_CanvasGroup.alpha = 0;
                DisableEnableCanvasInteraction(false);
            }
            else 
                m_CanvasGroup.DOFade(0, closeDuration).SetEase(closeEase).OnComplete(() =>
                {
                    DisableEnableCanvasInteraction(false);
                });
        }

        public override void OpenPanel()
        {
            InvokeOnPanelOpenStarted();
            m_CanvasGroup.DOFade(1, openDuration).SetEase(openEase).OnComplete(() =>
            {
                DisableEnableCanvasInteraction(true);
            });
        }

        private void DisableEnableCanvasInteraction(bool enable)
        {
            m_CanvasGroup.blocksRaycasts = enable;
            m_CanvasGroup.interactable = enable;
        }
    }
}
