using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity; 

    public Transform child; 
    public GameObject inventoryUI; 

    public CharacterController controller; 
    private Transform cam; 
    float rotationSpeed = 4.0f;

    private PlayerControls playerActionControls; 
    Vector2 move; 

    private bool waitingForInput = false; 

    private void Awake(){
        playerActionControls = new PlayerControls(); 

        //Quick Tool Inventory
        playerActionControls.Interaction.OpenWeaponQuickInventory.started += ctx => OpenQuickInventory(0); 
        playerActionControls.Interaction.OpenWeaponQuickInventory.canceled += ctx => CloseQuickInventory(); 
    
        //Quick Shield Inventory 
        playerActionControls.Interaction.OpenShieldQuickInventory.started += ctx => OpenQuickInventory(2); 
        playerActionControls.Interaction.OpenShieldQuickInventory.canceled += ctx => CloseQuickInventory(); 

        //Quick Bow Inventory 
        playerActionControls.Interaction.OpenBowQuickInventory.started += ctx => OpenQuickInventory(3); 
        playerActionControls.Interaction.OpenBowQuickInventory.canceled += ctx => CloseQuickInventory(); 

        //Quick Arrow Inventory 
        playerActionControls.Interaction.OpenArrowQuickInventory.started += ctx => OpenQuickInventory(1); 
        playerActionControls.Interaction.OpenArrowQuickInventory.canceled += ctx => CloseQuickInventory(); 
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

    private void OpenQuickInventory(int itemType){
        inventoryUI.GetComponent<InventoryUI>().SetupQuickInventory(itemType); 

        //show the quick inventory
        inventoryUI.SetActive(true); 
    }

    private void CloseQuickInventory(){
        inventoryUI.GetComponent<InventoryUI>().CloseInventory(); 
    }

    private IEnumerator CheckForInventoryInput(){
        //get further input 
        Vector2 xMovement = playerActionControls.Interaction.ChooseQuickInventory.ReadValue<Vector2>();
        //only care about x values (Left Right). Highlight next weapon
        if(xMovement.x > 0){
            inventoryUI.GetComponent<InventoryUI>().HighlightRightSlot(); 
        }
        else if(xMovement.x < 0){
            inventoryUI.GetComponent<InventoryUI>().HighlightLeftSlot(); 
        }
        //else they stayed on the current slot 

        //wait for a couple seconds for next input 
        yield return new WaitForSeconds(0.1f); 

        waitingForInput = false; 
    }

    List<Vector3> CalculateMovement(Transform cam, Vector2 movement, float playerSpeed)
    {
        //Stop vertical movement if grounded 
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //x z movement
        Vector3 move = (cam.forward * movement.y + cam.right * movement.x);
        move.y = 0f;
        Vector3 direction = move.normalized;
        move = move * playerSpeed; 

        // Changes the height position of the player..
        if (playerActionControls.Land.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        move += playerVelocity;

        List<Vector3> movementInfo = new List<Vector3>();
        movementInfo.Add(move);
        movementInfo.Add(direction); 
        return movementInfo; 
    }

    Quaternion CalculateRotation(Vector3 direction, Vector2 movement)
    {
        Quaternion rotation = transform.rotation; 

        //Rotate player with camera
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            rotation = Quaternion.Euler(0f, angle, 0f);
        }

        return rotation; 
    }

    void MovePlayer()
    {
        Vector2 playerInput = playerActionControls.Land.Move.ReadValue<Vector2>();
        //move
        List<Vector3> move = CalculateMovement(cam, playerInput, playerSpeed); 
        controller.Move(move[0] * Time.deltaTime);

        //rotate 
        transform.rotation = CalculateRotation(move[1], playerInput); 
    }

    void Update()
    {
        //Check if inventory is already up - avoid moving player if so
        if(playerActionControls.Interaction.OpenWeaponQuickInventory.ReadValue<float>() > .1f || 
        playerActionControls.Interaction.OpenShieldQuickInventory.ReadValue<float>() > .1f || 
        playerActionControls.Interaction.OpenBowQuickInventory.ReadValue<float>() > .1f || 
        playerActionControls.Interaction.OpenArrowQuickInventory.ReadValue<float>() > .1f){
            
            if(!waitingForInput){
                waitingForInput = true; 
                StartCoroutine(CheckForInventoryInput());
            }
        
            //Don't allow character to move so they can choose inventory item to equip instead 
            return; 
        }

        //Movement
        MovePlayer(); 
    }
}
