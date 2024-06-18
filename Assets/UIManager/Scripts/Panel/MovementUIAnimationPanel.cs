using DG.Tweening;
using UnityEngine;

namespace UIManagement
{
    /// <summary>
    /// This animated panel inherits AUIAnimatedPanel 
    /// This class moves panel on four direction to center
    /// </summary>
    /// 
    [RequireComponent(typeof(RectTransform))]
    public class MovementUIAnimationPanel : AUIAnimatedPanel
    {
        enum MoveDirection { Left, Right, Up,Down }

        [SerializeField] MoveDirection moveDirection ;
        [SerializeField] float closeDistance;

        [Tooltip("If true panel moves from left to center while opening and center to right while clossing")]
        [SerializeField] bool sameOpenCloseDirection;

        Vector2 closePosition;
        Vector2 startPosition;
        RectTransform rectTransform;
        private void Start()
        {
            InitializeOpenClosePositions();
            rectTransform = GetComponent<RectTransform>();
        }

        private void InitializeOpenClosePositions()
        {
            closePosition = GetClosePos();
            startPosition = GetStartPosition();
        }

        public override void OpenPanel()
        {
            InvokeOnPanelOpenStarted();
            InitializeOpenClosePositions();
            rectTransform.DOAnchorPos(Vector2.zero, openDuration).SetEase(openEase);
        }

        public override void ClosePanel(bool instantClose)
        {
            InvokeOnPanelCloseStarted();
            InitializeOpenClosePositions();
            if(instantClose)
                rectTransform.anchoredPosition = startPosition;
            else
                rectTransform.DOAnchorPos(closePosition, closeDuration).SetEase(closeEase).OnComplete(() =>
                {
                    rectTransform.anchoredPosition = startPosition;
                });
        }

        Vector2 GetClosePos()
        {
            return moveDirection switch
            {
                MoveDirection.Left => new Vector2(sameOpenCloseDirection ? closeDistance:-closeDistance, 0),
                MoveDirection.Right => new Vector2(sameOpenCloseDirection ? -closeDistance : closeDistance, 0),
                MoveDirection.Up => new Vector2(0, sameOpenCloseDirection ? closeDistance : -closeDistance),
                MoveDirection.Down => new Vector2(0, sameOpenCloseDirection ? -closeDistance : closeDistance),
                _ => new Vector2(0, 0),
            };
        }
        Vector2 GetStartPosition()
        {
            return moveDirection switch
            {
                MoveDirection.Left => new Vector2(-closeDistance, 0),
                MoveDirection.Right => new Vector2(closeDistance, 0),
                MoveDirection.Up => new Vector2(0, -closeDistance),
                MoveDirection.Down => new Vector2(0, closeDistance),
                _ => new Vector2(0, 0),
            };
        }
    }
}
