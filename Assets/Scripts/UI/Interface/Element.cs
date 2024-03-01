using FPS;
using UnityEngine;

namespace UI
{
    public class Element : MonoBehaviour
    {
        protected InterfaceManager interfaceManager;
        protected FPSCharacter character;

        protected virtual void Awake() { }
        protected virtual void Start() { }

        private void OnEnable()
        {
            if (interfaceManager == null) interfaceManager = GetComponentInParent<InterfaceManager>();
            if (interfaceManager == null) return;
            
            interfaceManager.RegisterElement(this);
            character = interfaceManager.character;
            Enabled();
        }

        private void OnDisable()
        {
            if (interfaceManager) interfaceManager.UnRegisterElement(this);
        }

        public void Run()
        {
            Tick();
        }
        
        protected virtual void Enabled() {}

        protected virtual void Tick(){}
    }
}