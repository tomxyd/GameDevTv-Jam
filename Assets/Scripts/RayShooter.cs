using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
