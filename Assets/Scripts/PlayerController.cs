using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 10;
    public float maxSpeed = 100;

    private int desiredLane = 1; //0 Left | 1 Middle | 2 Right
    public float laneDistance = 4; //Distance between 2 lanes
    public float laneChangeSpeed = 10;
    void Start()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.2f * Time.deltaTime;

        direction.z = forwardSpeed;
        // Inputs for the Lane

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        // calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        controller.Move(direction * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.fixedDeltaTime);
        controller.center = controller.center;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            //Debug.Log("hit");
            PlayerManager.gameOver = true;
            PlayerManager.isGameStarted = false;
        }
    }
}
