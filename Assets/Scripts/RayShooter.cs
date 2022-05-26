using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    [SerializeField] float damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<ReactiveTarget>())
                {
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    target.Die(damage);
                }
            }
        }
    }
}
