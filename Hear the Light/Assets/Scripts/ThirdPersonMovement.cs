using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    public Transform child; 


    public CharacterController controller; 
    private Transform cam; 
    float rotationSpeed = 4.0f;

    private PlayerControls playerActionControls; 
    Vector2 move; 

    private void Awake(){    
        playerActionControls = new PlayerControls(); 
    }

    private void OnEnable(){
        playerActionControls.Enable(); 
    }

    private void OnDisable(){
        playerActionControls.Disable(); 
    }

    void Start(){
        cam = Camera.main.transform; 
        child = transform.GetChild(0).transform; 
    }

    void Update()
    {

        //Movement
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = playerActionControls.Land.Move.ReadValue<Vector2>(); 
        Vector3 move = (cam.forward * movement.y + cam.right * movement.x); 
        move.y = 0f; 
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (playerActionControls.Land.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(movement != Vector2.zero){
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cam.localEulerAngles.y, child.localEulerAngles.z)); 
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed); 
        }
    }
}
