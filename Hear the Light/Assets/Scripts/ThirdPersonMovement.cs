using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller; 
    public Transform cam; 

    public float speed = 6f; 
    public float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity; 

    private PlayerControls playerActionControls; 
    Vector2 move; 

    private void Awake(){
        
        playerActionControls = new PlayerControls(); 
        playerActionControls.Land.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
		playerActionControls.Land.Move.canceled += ctx => move = Vector2.zero;  
    }

    private void OnEnable(){
        playerActionControls.Enable(); 
    }

    private void OnDisable(){
        playerActionControls.Disable(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = move.x; 
        float vertical = move.y; 

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; 
        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + 
            cam.eulerAngles.y; 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, 
            ref turnSmoothVelocity, turnSmoothTime); 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime); 
        }
    }
}
