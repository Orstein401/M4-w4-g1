using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SHoot();
        }
    }

    private void SHoot()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo);
        if (hitInfo.collider!=null)
        {
            Debug.Log("ho colpito qualcosa");
            if (hitInfo.collider.TryGetComponent<IHit>(out var objectHit))
            {
                Debug.Log("quella cosa aveva Hit");
                objectHit.GetHit();
            }

        }
    }
}
