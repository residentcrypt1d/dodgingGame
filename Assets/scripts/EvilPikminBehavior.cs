using UnityEngine;
public class EvilPikminBehavior : MonoBehaviour
{
    Rigidbody rb; // Add a low friction physics material to the monster's collider to help prevent the monster from snagging onto a tree
    public Transform playerCharacter; // Use the editor to drag the player object onto this
    public Transform targetPosition;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.linearDamping=1;
        rb.freezeRotation=true;
    }

    void FixedUpdate()
    {
        Vector3 target=transform.position+transform.forward+transform.right*Time.deltaTime; // looks around for the player
        
        Vector3 playerDirection=playerCharacter.position-transform.position;
        
        if (Vector3.Dot(playerDirection.normalized,transform.forward)>0.5f 
            && playerDirection.magnitude<50)// is the player within our sight
            
            if (Physics.Raycast(transform.position,playerDirection,out RaycastHit hit,50)) 
                // what's between us and the player

                if (hit.transform.CompareTag("Player")) // forcing myself to learn tags i die
                    target=playerCharacter.position; // make the player our target (which i will do twice to be safe.......)
                   
     
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
        
        Vector3 targetDirection=(target-transform.position).normalized;
        rb.AddForce(targetDirection*10); // head towards the target position (10 is the speed)
        rb.MoveRotation(Quaternion.LookRotation(targetDirection)); // look towards the target
    }
}
