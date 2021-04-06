using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotSpeed = 1;
    public Transform target;
    public Transform playerFox;
    float mouseX;
    float mouseY;
    public float damping = .1f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        camController();
    }

    private void FixedUpdate()
    {
        Quaternion desiredPosition = Quaternion.Euler(0, mouseX, 0);
        Quaternion smoothedPosition = Quaternion.Lerp(playerFox.rotation, desiredPosition, Time.deltaTime * damping);
        playerFox.rotation = smoothedPosition;
    }

    void camController()
    {
        if (!pauseMenu.isPaused)
        {
            mouseX += Input.GetAxis("Mouse X") * rotSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
            mouseY = Mathf.Clamp(mouseY, -30, 60);
            transform.LookAt(target);
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

            
            //playerFox.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
