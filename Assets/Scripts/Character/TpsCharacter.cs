using System;
using Core.Attributes;
using Scriptables;
using UnityEngine;
using Utilities;

namespace Character
{
    public class TpsCharacter : MonoBehaviour
    {
        [SerializeField] SkinnedMeshRenderer meshRenderer;
        [SerializeField] [ReorderableList] private TpMaterial[] mats;
        [SerializeField, OnValueChanged(nameof(ShowChanged))] bool showTps;

        private CharacterMaterial currentMaterial;
        private Material invisibleMat;

        [Button("Setup Mat List")]
        private void SetUpList()
        {
            mats = new TpMaterial[meshRenderer.materials.Length];
        } 
        
        
        private void Start()
        {
            currentMaterial = GlobalSettings.Instance.GetDefaultMaterial();
            invisibleMat = GlobalSettings.Instance.GetInvisibleMat();
            
            ShowChanged();
            ApplyMaterial();
        }

        private void ApplyMaterial()
        {
            Material[] materials = new Material[mats.Length];
            for (var i = 0; i < materials.Length; i++) materials[i] = mats[i].material;

            meshRenderer.materials = materials;
        }

        public void ShowChanged()
        {
            foreach (var mat in mats)
            {
                mat.material = mat.materialType == MaterialType.AlwaysVisible ? currentMaterial.bodyMaterial : showTps ? currentMaterial.bodyMaterial : invisibleMat;
            }
            ApplyMaterial();
        }
    }
}