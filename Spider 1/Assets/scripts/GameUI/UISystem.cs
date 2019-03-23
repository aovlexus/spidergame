using UnityEngine;
using UnityEngine.Events;

namespace GameUI
{
    public class UISystem : MonoBehaviour
    {
        
        [Header("system Events")]
        public UIScreen startScreen;
        public UnityEvent onSwitchScreen = new UnityEvent();

        private UIScreen[] _screens = new UIScreen[0];

        private UIScreen _currentScreen;
        public UIScreen CurrentScreen => _currentScreen;
        
        private UIScreen _previousScreen;
        public UIScreen PreviousScreen => _previousScreen;

        // Start is called before the first frame update
        private void Start()
        {
            _screens = GetComponentsInChildren<UIScreen>(true);

            if (startScreen)
            {
                SwitchScreens(startScreen);
            }
        }

        // Update is called once per frame
        public void SwitchScreens(UIScreen screen)
        {
            if (!screen) return;

            if (_currentScreen)
            {
                _previousScreen = _currentScreen;
            }

            CloseAllScreens();
            _currentScreen = screen;
            _currentScreen.StartScreen();
            _currentScreen.gameObject.SetActive(true);

            onSwitchScreen?.Invoke();
        }

        private void CloseAllScreens()
        {
            foreach (var screen in _screens)
            {
                screen.CloseScreen();
            }
        }
        public void GoToPreviousScreen()
        {
            if (_previousScreen)
            {
                SwitchScreens(_previousScreen);
            }
        }
    }
}
