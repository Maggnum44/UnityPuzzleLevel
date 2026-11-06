using Gameplay.Interactions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Character{
    public class UserInputMovement : MonoBehaviour
    {
        private CharacterMovement _characterMovement;

        private CharacterHabilities _characterHabilities;

        private CharacterInteractor _interactor;
        void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _interactor = GetComponent<CharacterInteractor>();

            if(_characterMovement == null)
            {
                Debug.LogError("[UserInputMovement] CharacterMovement is null! Add a CharacterMovement component to the GameObject.");
            }

            _characterHabilities = GetComponent<CharacterHabilities>();

            if(_characterHabilities == null)
            {
                Debug.LogError("[UserInputMovement] CharacterHabilities is null! Add a CharacterHabilities component to the GameObject.");
            }
        }
        void Update()
        {
            Vector2 inputMovementVector = InputSystem.actions["Move"].ReadValue<Vector2>();
            _characterMovement.Move(inputMovementVector);

            Vector3 lookVector = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);
            
            if(lookVector.magnitude > 0.1f)
                _characterMovement.LookAt(lookVector + transform.position);

            if (InputSystem.actions["Jump"].WasPressedThisFrame())
            {
                _characterMovement.TriggerJump();
            }

            if (InputSystem.actions["Jump"].WasReleasedThisFrame())
            {
                _characterMovement.CancelJump();
            }
            if (InputSystem.actions["Attack"].WasReleasedThisFrame())
            {
                _characterHabilities.Attack();
            }
            if (InputSystem.actions["Interact"].WasPressedThisFrame())
            {
                _interactor.TriggerInteraction();
            }
        }
    }
}