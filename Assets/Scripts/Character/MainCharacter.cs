using Character.Interfaces;
using Core;
using Core.Interfaces;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IUpdateListener, ICharacter
    {
        public CharacterView CharacterView { get; set; }
        public CharacterModel CharacterModel { get; set; }

        private readonly Updater _updater;
        private readonly IInputService _inputService;

        private bool _isMovingRight = false;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService)
        {
            CharacterView = characterView;
            CharacterModel = characterModel;
            _updater = updater;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _updater.AddListener(this);
            CharacterView.Initialize();
            CharacterView.OnDestroyHandler += OnDestroy;
            _inputService.OnScreenTap += Turn;
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void Turn()
        {
            _isMovingRight = !_isMovingRight;

            if (_isMovingRight)
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(5, 0);
            }
            else
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(0, 5);
            }
        }

        private void OnDestroy()
        {
            _updater.RemoveListener(this);
            CharacterView.OnDestroyHandler -= OnDestroy;
        }
    }
}
