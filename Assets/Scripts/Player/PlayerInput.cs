using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        private InputControls _inputControls;

        private void Awake()
        {
            _inputControls = new InputControls();
            _inputControls.Player.Move.performed += OnMove;
        }

        private void OnEnable()
        {
            _inputControls.Enable();
        }

        private void OnMove(InputAction.CallbackContext obj)
        {
            _playerController.Move();
        }

        private void OnDisable()
        {
            _inputControls.Disable();
        }

        private void OnDestroy()
        {
            _inputControls.Player.Move.performed -= OnMove;
        }
    }
}