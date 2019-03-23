using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIScreen : MonoBehaviour
    {
        #region Variables

        [Header("Main Variables")] public Selectable startSelectable;

        [Header("Screen Events")] public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();
        private CanvasGroup _canvasGroup;
        
        private const float Invisible = 0f; 
        private const float Visible = 1f;
        #endregion

        #region UnityRenderingPipeline
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            if (startSelectable)
            {
                EventSystem.current.SetSelectedGameObject(startSelectable.gameObject);
            }
        }
        #endregion

        public virtual void StartScreen()
        {
            onScreenStart?.Invoke();
            SetActive(true);
        }
        
        public virtual void CloseScreen()
        {
            onScreenClose?.Invoke();
            SetActive(false);
        }

        private void SetActive(bool active)
        {
            if (!_canvasGroup || _canvasGroup == null) return;

            _canvasGroup.alpha = active ? Visible : Invisible;
            _canvasGroup.interactable = active;
            _canvasGroup.blocksRaycasts = active;
        }
    }
}
