using Character.Interfaces;
using Core;
using Core.Interfaces;
using Sounds.Interfaces;
using System;
using UI.Interfaces;
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
        private readonly ISoundFactory _soundFactory;
        private readonly ICounter<float> _scoreCounter;
        private bool _isMovingRight;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater, IInputService inputService,
            IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer, ISoundFactory soundFactory,
            ICounter<float> scoreCounter)
        {
            CharacterView = characterView;
            CharacterModel = characterModel;
            _updater = updater;
            _soundFactory = soundFactory;
            _scoreCounter = scoreCounter;

            OnCharacterCreated(inputService, initializator, clearer);
        }

        private void OnCharacterCreated(IInputService inputService, IListenersHandler<IInitializable> initializator, 
            IListenersHandler<IClearable> clearer)
        {
            initializator.AddListener(this);
            clearer.AddListener(this);
            inputService.OnScreenTap += Turn;
            CharacterView.Initialize();
            CharacterView.OnDestroyHandler += OnDestroy;
            CharacterView.ObstacleDetector.OnCollided += Die;
            Extensions.Deactivate(CharacterView.gameObject);
        }

        public void Initialize()
        {
            Extensions.Activate(CharacterView.gameObject);
            _updater.AddFixedUpdateListener(this);
        }

        public void FixedTick(float deltaTime)
        {
            _scoreCounter.AddValue(CharacterModel.ScoreToAdd);
            if (_isMovingRight)
            {
                CharacterView.Rigidbody2D.velocity = new Vector2(CharacterModel.Speed, 0f);
                CharacterView.CharacterModel.transform.eulerAngles = new Vector3(0f, 0f, -90f);
            }
            else
            {
                CharacterView.CharacterModel.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                CharacterView.Rigidbody2D.velocity = new Vector2(0f, CharacterModel.Speed);
            }
        }

        private void Turn()
        {
            _isMovingRight = !_isMovingRight;
            _soundFactory.PlaySound(CharacterModel.TurnSound);
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
