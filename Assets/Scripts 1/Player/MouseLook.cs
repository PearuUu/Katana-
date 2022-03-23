using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 5;
    [SerializeField] Transform playerBody;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        CameraControl();
    }
    
    void CameraControl()
    {
        xRotation -= GetMouseInput().Y;
        xRotation = Mathf.Clamp(xRotation ,-90, 90);
        playerBody.Rotate(Vector3.up * GetMouseInput().X);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }

    (float X, float Y) GetMouseInput()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 100;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 100;

        return (mouseX, mouseY);

    }
}
