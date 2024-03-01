using Core;
using UnityEngine;

namespace FPS
{
    [AddComponentMenu("FPS/FPSCharacter")]
    public class FPSCharacter : MonoBehaviour
    {
        public delegate void OnInputUpdatedD(ref PlayerInput input);
        public OnInputUpdatedD OnInputUpdated;

        private FPSMovement fpsMovement;
        private FPSCamera fpsCamera;
        private FPSAnimator fpsAnimator;
        private FPSInventory fpsInventory;
        private FPSMotionApplier fpsMotionApplier;
        
        PlayerInput input;
        
        public FPSMovement FPSMovement
        {
            get => fpsMovement;
            set => fpsMovement = value;
        }

        public FPSCamera FPSCamera
        {
            get => fpsCamera;
            set => fpsCamera = value;
        }
        
        public FPSAnimator FPSAnimator
        {
            get => fpsAnimator;
            set => fpsAnimator = value;
        }
        
        public FPSInventory FPSInventory
        {
            get => fpsInventory;
            set => fpsInventory = value;
        }
        
        public FPSMotionApplier FPSMotionApplier
        {
            get => fpsMotionApplier;
            set => fpsMotionApplier = value;
        }
        
        private void Awake()
        {
            fpsMovement = GetComponent<FPSMovement>();
            fpsCamera = GetComponent<FPSCamera>();
            fpsAnimator = GetComponent<FPSAnimator>();
            fpsInventory = GetComponent<FPSInventory>();
            fpsMotionApplier = GetComponent<FPSMotionApplier>();
        }

        private void Update()
        {
            UpdateInput();
        }
        
        private void UpdateInput()
        {
            // todo: Update input
            if (InputManager.Instance)
            {
                input.MoveDir = new Vector2(InputManager.Instance.Horizontal, InputManager.Instance.Vertical);
                input.LookDir = InputManager.Instance.Look;

                input.Jump = InputManager.Instance.IsJump;
                input.Sprint = InputManager.Instance.IsSprint;
                input.Crouch = InputManager.Instance.IsCrouch;
                input.CrouchDown = InputManager.Instance.Crouch == ButtonState.Pressed;
                input.Attack = InputManager.Instance.Attack;
                input.Aim = InputManager.Instance.Aim;
                input.MouseWheel = InputManager.Instance.MouseWheel;
                input.Interact = InputManager.Instance.Interact;
                input.Reload = InputManager.Instance.Reload;
            }
            
            OnInputUpdated?.Invoke(ref input);
        }


        #region API

        public bool IsMoving() => input.MoveDir != Vector2.zero;
        
        public bool IsAiming() => (input.Aim == ButtonState.Held || input.Aim == ButtonState.Pressed) &&
                                  fpsInventory != null && fpsInventory.CurrentInHand != null && fpsInventory.CurrentInHand.IsGun;
        public bool IsCrouching() => input.Crouch;
        
        public bool IsGrounded() => fpsMovement.IsGrounded;
        
        public Vector2 GetMovementInput() => input.MoveDir;

        public Vector3 GetVelocity() => fpsMovement ? fpsMovement.GetVelocity() : Vector3.zero;
        
        public bool IsSprinting() => input.Sprint;

        public void TriggerHands(bool state)
        {
            if (fpsAnimator == null) return;
            fpsAnimator.SetHandsActive(state);
        }

        #endregion

    }
}