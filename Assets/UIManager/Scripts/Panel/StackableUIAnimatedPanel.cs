using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIManagement
{
    /// <summary>
    /// This animated panel inherits AUIAnimatedPanel 
    /// This class is used when multiple panels has to open/closed one after another on certain interval
    /// </summary>
    /// 
    public class StackableUIAnimatedPanel : AUIAnimatedPanel
    {
        [SerializeField] float interval;
        [SerializeField] bool closePanelFromLast;
        [SerializeField] AUIAnimatedPanel[] animatedUIPanels;
        public override void ClosePanel(bool instantClose)
        {
            StartCoroutine(ClosePanelCour(instantClose));
        }
        IEnumerator ClosePanelCour(bool instantClose)
        {

            if (instantClose)
            {
                foreach (var anim in animatedUIPanels)
                    anim.ClosePanel(instantClose);
            }
            if (closePanelFromLast)
            {
                for (int i = animatedUIPanels.Length - 1; i >= 0; i--)
                {
                    animatedUIPanels[i].ClosePanel(instantClose);
                    yield return new WaitForSeconds(interval);
                }
            }
            else
            {
                foreach (var anim in animatedUIPanels)
                {
                    anim.ClosePanel(instantClose);
                    yield return new WaitForSeconds(interval);
                }
            }
        }
        public override void OpenPanel()
        {
            StartCoroutine(OpenPanelCour());
        }
        IEnumerator OpenPanelCour()
        {
            foreach (var anim in animatedUIPanels)
            {
                anim.OpenPanel();
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
