using UnityEngine;

namespace UIManagement
{
    /// <summary>
    /// This class has list of all the available ui panels
    /// Also stores previous open panel for back functionality
    /// </summary>
    public class AllUIPanelsHolder : MonoBehaviour
    {
        [SerializeField] AUIAnimatedPanel[] allUIPanels;

        private void Start()
        {
            foreach (var p in allUIPanels)
                if (p != null) p.OnPanelOpenStarted += CloseAllOtherPanels;

            //if(allUIPanels.Length > 0)
            //    allUIPanels[0].OpenPanel();
            CloseAllPanels();
        }
        private void OnDestroy()
        {
            foreach (var p in allUIPanels)
                if (p != null) p.OnPanelOpenStarted -= CloseAllOtherPanels;
        }

        private void CloseAllOtherPanels(AUIAnimatedPanel activePanel)
        {
            foreach (var panel in allUIPanels)
                if (panel != null && panel != activePanel) panel.ClosePanel(true);
        }

        private void CloseAllPanels()
        {
            foreach (var panel in allUIPanels)
                if (panel != null) panel.ClosePanel(true);
        }
    }
}
