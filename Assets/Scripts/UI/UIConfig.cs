using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "UI / New UI Config")]
    public class UIConfig : ScriptableObject    
    {
        [SerializeField] private float _multiplierTime;

        [Header("UI Prefabs")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private GameEndScreen _gameEndScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private GameplayScreen _gameplayScreen;
        

        public Canvas Canvas => _canvas;
        public MenuScreen MenuScreen => _menuScreen;
        public GameEndScreen GameEndScreen => _gameEndScreen;
        public SettingsScreen SettingScreen => _settingsScreen;
        public GameplayScreen GamePlayScreen => _gameplayScreen;
        public float MultiplierTime => _multiplierTime;
    }
}
