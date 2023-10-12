using Character.Interfaces;
using Core;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IFixedUpdateListener, ICharacter
    {
        public event Action OnDied;
        public CharacterView CharacterView { get; private set; }
        public CharacterModel CharacterModel { get; private set; }
        public Transform Transform => CharacterView.transform;

        public bool IsMovingRight 
        { 
            get => _isMovingRight; 
            set => _isMovingRight = value; 
        }

        public float MovementSpeed
        {
            get => CharacterModel.Speed;
            set => CharacterModel.Speed = value;
        }

        private readonly Updater _updater;
        private readonly IInputService _inputService;
        private bool _isMovingRight;

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
            _updater.AddFixedUpdateListener(this);
            CharacterView.OnDestroyHandler += OnDestroy;
            _inputService.OnScreenTap += Turn;
        }

        public void FixedTick(float deltaTime)
        {
            if (_isMovingRight)
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(CharacterModel.Speed, 0f);
            }
            else
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(0f, CharacterModel.Speed);
            }
        }

        private void Turn()
        {
            _isMovingRight = !_isMovingRight;
        }

        private void OnDestroy()
        {
            _updater.RemoveFixedUpdateListener(this);
            CharacterView.OnDestroyHandler -= OnDestroy;
        }
    }
}
