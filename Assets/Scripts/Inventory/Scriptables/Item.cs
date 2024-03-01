using Core.Attributes;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Snowy/Inventory/BaseItem")]
    public class Item : ScriptableObject
    {
        [Header("General Settings")]
        public int id = -1;
        public string itemName;
        [TextArea] public string description;
        [ShowAssetPreview] public Sprite icon;
        
        public bool isStackable;
        [EnableIf(nameof(isStackable)), Min(1)] public int maxStack = 1;

        public bool canHaveInHand;
        [ShowAssetPreview, ShowIf(nameof(canHaveInHand))] public InHandItem inHandPrefab;
        
        [ShowIf(nameof(canHaveInHand))]
        public AnimatorOverrideController handsAnimatorController;
        [ShowIf(nameof(canHaveInHand))]
        public AnimatorOverrideController bodyAnimatorController;
    }
}