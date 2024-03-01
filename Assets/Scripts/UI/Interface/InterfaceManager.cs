using System;
using System.Collections.Generic;
using FPS;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(FPSCharacter))]
    public class InterfaceManager : MonoBehaviour
    {
        [HideInInspector] public FPSCharacter character;
        private event Action OnUpdate;

        private void Awake()
        {
            character = GetComponent<FPSCharacter>();
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        public void RegisterElement(Element element)
        {
            if (!character) character = GetComponent<FPSCharacter>();
            OnUpdate += element.Run;
        }

        public void UnRegisterElement(Element element)
        {
            OnUpdate -= element.Run;
        }
    }
}