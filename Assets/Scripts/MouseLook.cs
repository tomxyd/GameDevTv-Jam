using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor;
    public float sensitivityVer;
    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float verticalRot = 0f;

    private void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null) rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXAndY:
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer * Time.deltaTime;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor * Time.deltaTime;
                float horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
                break;
            case RotationAxes.MouseY:
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVer * Time.deltaTime;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

                horizontalRot = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);

                break;
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor * Time.deltaTime, 0);
                break;
        }
    }
}
