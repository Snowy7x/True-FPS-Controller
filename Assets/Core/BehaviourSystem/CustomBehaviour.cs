using System;
using UnityEngine;

namespace _Core.BehaviourSystem
{
    public class CustomBehaviour : MonoBehaviour, IManagedObject
    {
        private void OnEnable()
        {
            this.Register();
        }

        private void OnDisable()
        {
            this.Unregister();
        }
    }
}