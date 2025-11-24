using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlatformControl : MonoBehaviour
{
    [SerializeField] private Transform selfTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minX = -8f;
    [SerializeField] private float maxX = 8f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AudioSource audioSource;
    [Inject]
    private GameInputAction inputAction; 

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.PlatformMove.performed += Move;
    }

    private void OnDisable()
    {
        inputAction.Player.PlatformMove.performed -= Move;
        inputAction.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector2 deltaScreen = context.ReadValue<Vector2>();
        float deltaX = deltaScreen.x;

        if (Mathf.Abs(deltaX) < 0.1f) return;

        float worldDX = ConvertPixelDeltaToWorldX(deltaX);

      
        Vector3 currentPos = transform.position;
        currentPos.x += worldDX * sensitivity;

        currentPos.x = Mathf.Clamp(currentPos.x, minX, maxX);

        selfTransform.position = currentPos;
    }

    private float ConvertPixelDeltaToWorldX(float pixelDeltaX)
    {
        float worldHeight = mainCamera.orthographicSize * 2f;
        
       
        float worldUnitsPerPixel = worldHeight / Screen.height;

        return pixelDeltaX * worldUnitsPerPixel;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.Play();
        animator.Play("Platform");
    }
}
