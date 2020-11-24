using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; 
    public GameObject player; 

    private PlayerControls playerActionControls; 

    private void Awake(){    
        playerActionControls = new PlayerControls(); 
    }

    private void OnEnable(){
        playerActionControls.Enable(); 
    }

    private void OnDisable(){
        playerActionControls.Disable(); 
    }

    public virtual void Interact(){
        //to be overwritten 
        Debug.Log("Interacting"); 
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, radius); 
    }

    void Update(){
        float interactButtonPressed = playerActionControls.Interaction.SelectObj.ReadValue<float>(); 
        
        if(interactButtonPressed >= 1){
            //check if player is within radius 
            float distance = Vector3.Distance(player.transform.position, transform.position); 
            if(distance <= radius){
                //within radius, check if facing the obj
                RaycastHit hit; 
                Debug.Log("Within radius"); //player.transform.TransformDirection(Vector3.forward)
                bool didHit = Physics.Raycast(player.transform.position, 
                player.transform.TransformDirection(Vector3.forward), out hit, radius * 2); 
                Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.DrawLine(player.transform.position, player.transform.TransformDirection(Vector3.forward) * (radius * 2)); 
                if(didHit){
                    //It hit objects 
                    
            Debug.Log("Did Hit");
                    if(hit.transform.gameObject == transform.Find("hitArea").gameObject){
                        // perform interaction
                        Interact(); 
                    }
                }
            }
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
