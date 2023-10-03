using Character.Interfaces;
using Core;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IUpdateListener, ICharacter
    {
        public CharacterView CharacterView { get; set; }
        public CharacterModel CharacterModel { get; set; }
        public bool IsMovingRight { get => _isMovingRight; set => _isMovingRight = value; }

        private readonly Updater _updater;
        private readonly IInputService _inputService;

        private bool _isMovingRight = false;

        public event Action<bool> OnTurned;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService)
        {
            CharacterView = characterView;
            CharacterModel = characterModel;
            _updater = updater;
            _inputService = inputService;
        }

        public void Initialize()
        {
            CharacterView.Initialize();
            _updater.AddListener(this);
            CharacterView.OnDestroyHandler += OnDestroy;
            _inputService.OnScreenTap += Turn;
        }

        public void Tick(float deltaTime)
        {
            
        }

        private void Turn()
        {
            _isMovingRight = !_isMovingRight;
            OnTurned?.Invoke(_isMovingRight);

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
