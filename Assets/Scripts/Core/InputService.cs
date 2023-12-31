﻿using Core.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class InputService : IInputService
    {
        public event Action OnScreenTap;
        private readonly Updater _updater;

        private List<RaycastResult> _uiRaycastBuffer = new List<RaycastResult>();   

        public InputService(Updater updater, IListenersHandler<IInitializable> initializator, IListenersHandler<IClearable> clearer)
        {
            _updater = updater;
            initializator.AddListener(this);
            clearer.AddListener(this);
        }

        public void Initialize()
        {
            _updater.AddUpdateListener(this);
        }

        public void Tick(float deltaTime)
        {
            if (HasTouched() && NotOverUI())
            {
                OnScreenTap?.Invoke();
            }
        }

        public void Clear()
        {
            _updater.RemoveUpdateListener(this);
        }

        private bool NotOverUI()
        {
            var eventData = new PointerEventData(EventSystem.current);
#if UNITY_EDITOR
            eventData.position = Input.mousePosition;
#else
            eventData.position = Input.GetTouch(0).position;
#endif
            EventSystem.current.RaycastAll(eventData, _uiRaycastBuffer);

            return _uiRaycastBuffer.Count == 0;
        }

        private bool HasTouched()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}
