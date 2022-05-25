using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public static bool cameraLock = false;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.cameraLock = true;
    }
    void Update() {
        if (!cameraLock) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
