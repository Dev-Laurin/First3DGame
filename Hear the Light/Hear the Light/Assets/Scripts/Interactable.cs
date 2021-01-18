using UnityEngine;
using UnityEngine.InputSystem; 

public class Interactable : MonoBehaviour
{
    public float radius = 3f; 
    public GameObject player; 

    private PlayerControls playerActionControls; 

    private void Awake(){    
        playerActionControls = new PlayerControls(); 
        playerActionControls.Interaction.SelectObj.started += ctx => InteractionDetected(); 
    }

    private void OnEnable(){
        playerActionControls.Enable(); 
    }

    private void OnDisable(){
        playerActionControls.Disable(); 
    }

    public virtual void Interact(){
        //to be overwritten 
    }

    public void InteractionDetected(){
        //check if player is within radius 
        float distance = Vector3.Distance(player.transform.position, transform.position); 
        if(distance <= radius){
            //within radius, check if facing the obj
            RaycastHit hit; 
            bool didHit = Physics.Raycast(player.transform.position, 
            player.transform.TransformDirection(Vector3.forward), out hit, radius * 2); 
            Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.DrawLine(player.transform.position, player.transform.TransformDirection(Vector3.forward) * (radius * 2)); 
            if(didHit){
                //It hit objects 
                if(hit.transform.gameObject == transform.Find("hitArea").gameObject){
                    // perform interaction
                    Interact(); 
                }
            }
        }
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
