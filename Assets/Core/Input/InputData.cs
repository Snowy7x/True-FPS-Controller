using System;
using _Core.Utils;
using UnityEngine;

namespace _Core.Input
{
    [CreateAssetMenu(fileName = "InputData", menuName = "Core/Input/InputData", order = 0)]
    public class InputData : ScriptableObject
    {
        public InputButton[] buttons;
    }
    
    [Serializable]
    public class InputButton
    {
        public string name;
        public ButtonType type;
    }
}