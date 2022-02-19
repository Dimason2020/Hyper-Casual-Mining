using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    private PlayerInput inputActions;
    private Camera cameraMain;

    #region OnEnable/OnDisable
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    #endregion

    private void Awake()
    {
        inputActions = new PlayerInput();
        cameraMain = Camera.main;
    }

    private void Start()
    {
        inputActions.Gameplay.Click.started += _ => OnClicked();
    }

    private void OnClicked()
    {
        ShootRay();
    }

    private void ShootRay()
    {
        Ray ray = cameraMain.ScreenPointToRay(
            inputActions.Gameplay.Position.ReadValue<Vector2>()); ;

        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            if(raycastHit.collider.TryGetComponent(
                out MineralClickHandler mineralClickHandler))
            {
                mineralClickHandler.OnObjectClicked();
            }
        }

    }
}
