using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;
    public bool playerIsSafe = false;


    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;


    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
        


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * Time.deltaTime * playerSpeed);

        


    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Spot Light")
        {
            playerIsSafe = true;
        }
        else {
            playerIsSafe = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.name == "Spot Light")
        {
            playerIsSafe = false;

        }
    }
}
