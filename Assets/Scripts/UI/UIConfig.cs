using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "UI / New UI Config")]
    public class UIConfig : ScriptableObject    
    {
        [Header("UI Prefabs")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private GameEndScreen _gameEndScreen;
        [SerializeField] private GameplayScreen _gameplayScreen;
        [SerializeField] private GameplayScreenModel _gameplayScreenModel;
        
        public Canvas Canvas => _canvas;
        public MenuScreen MenuScreen => _menuScreen;
        public GameEndScreen GameEndScreen => _gameEndScreen;
        public GameplayScreen GamePlayScreen => _gameplayScreen;
        public GameplayScreenModel GameplayScreenModel => _gameplayScreenModel;
        
    }
}
