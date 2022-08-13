// See https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/HowDoI.html#create-a-simple-fire-type-action

using UnityEngine;
using UnityEngine.InputSystem;

public class KeyTest : MonoBehaviour
{
    [SerializeField] private KeyMode _keyMode;
    [SerializeField] private InputAction _inputAction;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        if (_keyMode == KeyMode.SpecificKey)
        {
            _inputAction.performed += OnSpecificKeyPressed;
        }
        else
        {
            _inputAction.performed += OnAnyKeyPressed; ;
        }
    }

    private void OnEnable()
    {
        _inputAction.Enable();
    }

    private void OnDisable()
    {
        _inputAction.Disable();
    }

    private void OnAnyKeyPressed(InputAction.CallbackContext action)
    {
        if (action.performed && Keyboard.current.nKey.wasPressedThisFrame)
        {
            _meshRenderer.enabled = !_meshRenderer.enabled;
        }
    }

    private void OnSpecificKeyPressed(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            _meshRenderer.enabled = !_meshRenderer.enabled;
        }
    }
}
