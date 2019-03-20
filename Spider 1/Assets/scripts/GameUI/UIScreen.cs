using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameUI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIScreen : MonoBehaviour
    {
        #region Variables

        [Header("Main Variables")] public Selectable StartSelectable;

        [Header("Screen Events")] public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();

        private Animator _animator;
        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Close = Animator.StringToHash("Close");

        #endregion

        void Start()
        {
            _animator = GetComponent<Animator>();
            if (StartSelectable)
            {
                EventSystem.current.SetSelectedGameObject(StartSelectable.gameObject);
            }
        }

        public virtual void StartScreen()
        {
            onScreenStart?.Invoke();
            SetAnimatorTrigger(Show);
            Debug.Log("Show");
        }
        
        public virtual void CloseScreen()
        {
            onScreenClose?.Invoke();
            SetAnimatorTrigger(Close);
        }

        private void SetAnimatorTrigger(int id)
        {
            if (_animator)
                _animator.SetTrigger(id);            
        }
    }
}
