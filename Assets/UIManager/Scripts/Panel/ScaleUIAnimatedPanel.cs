using DG.Tweening;
using UnityEngine;

namespace UIManagement
{
    /// <summary>
    /// This animated panel inherits AUIAnimatedPanel 
    /// This class scles in or out the panel
    /// </summary>
    /// 
    public class ScaleUIAnimatedPanel : AUIAnimatedPanel
    {
        public override void ClosePanel(bool instantClose)
        {
            InvokeOnPanelCloseStarted();
            if(instantClose) 
                transform.localScale = Vector2.zero;
            else 
                transform.DOScale(0,closeDuration).SetEase(closeEase);
        }

        public override void OpenPanel()
        {
            InvokeOnPanelOpenStarted();
            transform.DOScale(1, openDuration).SetEase(openEase);
        }
    }
}
