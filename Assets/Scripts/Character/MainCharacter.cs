using Character.Interfaces;
using Core;
using Core.Interfaces;
using System;
using UnityEngine;
using Utils;

namespace Character
{
    public class MainCharacter : ICharacter
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
        }

        private readonly Updater _updater;
        private bool _isMovingRight;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService,
            IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer)
        {
            CharacterView = characterView;
            CharacterModel = characterModel;
            _updater = updater;
            initializator.AddListener(this);
            clearer.AddListener(this);
            Extensions.Deactivate(CharacterView.gameObject);
            inputService.OnScreenTap += Turn;
            CharacterView.Initialize();
            CharacterView.OnDestroyHandler += OnDestroy;
            CharacterView.ObstacleDetector.OnCollided += Die;
        }

        public void Initialize()
        {
            Extensions.Activate(CharacterView.gameObject);
            
            _updater.AddFixedUpdateListener(this);
            
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

        private void Die()
        {
            OnDied?.Invoke();
        }

        public void Clear()
        {
            Extensions.Deactivate(CharacterView.gameObject);
            CharacterView.transform.position = CharacterModel.StartPosition;
            _updater.RemoveFixedUpdateListener(this);
            CharacterView.TrailRenderer.Clear();
        }

        private void OnDestroy()
        {
            _updater.RemoveFixedUpdateListener(this);
            CharacterView.OnDestroyHandler -= OnDestroy;
        }
    }
}
