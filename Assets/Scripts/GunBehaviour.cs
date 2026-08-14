using UnityEngine;
using UnityEngine.InputSystem;

public class GunBehaviour : MonoBehaviour
{
    public System.Action<bool> TARGET_AIMMING;
    public bool stopGame { get; private set; }

    [SerializeField] private Transform gunTransform;

    void Update()
    {
        if (stopGame)
            return;

        PointGun();
    }

    void PointGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.tag == "Target")
            {
                TARGET_AIMMING?.Invoke(true);

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    Target target = hit.transform.gameObject.GetComponent<Target>();

                    target?.Hit();
                }
            }
            else
            {
                TARGET_AIMMING?.Invoke(false);
            }
        }
        else
        {
            TARGET_AIMMING?.Invoke(false);
        }

        Vector3 targetPoint = ray.origin + ray.direction * 100;
        Vector3 direction = targetPoint - gunTransform.position;

        gunTransform.rotation = Quaternion.LookRotation(direction);
    }

    public void StopGame(bool stop)
    {
        stopGame = stop;
    }
}