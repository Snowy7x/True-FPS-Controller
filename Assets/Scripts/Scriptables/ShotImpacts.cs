using System;
using System.Linq;
using Core.Attributes;
using UnityEngine;

namespace Scriptables
{
    [Serializable]
    public class Impact
    {
        [Tag] public string tag;
        [ShowAssetPreview] public GameObject impact;
    }

    [CreateAssetMenu(fileName = "Shot Impacts", menuName = "Snowy/FPS/Shot Impacts")]
    public class ShotImpacts : ScriptableObject
    {
        [ReorderableList] public Impact[] impacts;
    }
}