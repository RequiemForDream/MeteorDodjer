using Character.Interfaces;
using Core;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class MainCharacter : IUpdateListener, ICharacter
    {
        public event Action OnDied;
        public CharacterView CharacterView { get; set; }
        public CharacterModel CharacterModel { get; set; }
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
            _updater.AddUpdateListener(this);
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
                CharacterView.Rigidbody2D.velocity = new Vector2(CharacterModel.Speed, 0);
            }
            else
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(0, CharacterModel.Speed);
            }
        }

        private void OnDestroy()
        {
            _updater.RemoveUpdateListener(this);
            CharacterView.OnDestroyHandler -= OnDestroy;
        }
    }
}
