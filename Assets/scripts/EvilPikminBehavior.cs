using UnityEngine;
public class EvilPikminBehavior : MonoBehaviour
{
    Rigidbody rb;
    public Transform playerCharacter;
    public Transform targetPosition;

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        rb.linearDamping = 1;
        rb.freezeRotation = true;
    }

    void FixedUpdate() // per the recommendation of the youtube tutorial i followed for this
    {
        Vector3 target = transform.position + transform.forward + transform.right * Time.deltaTime; // pikmin looks around for the player
        
        Vector3 playerDirection = playerCharacter.position - transform.position;
        
        if (Vector3.Dot(playerDirection.normalized,transform.forward) > 0.5f 
            && playerDirection.magnitude<50) // is the player within the pikmin's sight?
            
            if (Physics.Raycast(transform.position,playerDirection,out RaycastHit hit,50)) 
                // what's btwn pikmin and the player?

                if (hit.transform.CompareTag("Player")) // forcing myself to learn tags i die i die i die
                    target=playerCharacter.position; // make the player pikmin target (i think i figured it out ?? not touching this its working and if i breathe on it it'll prob explode)
                   
     
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
        
        Vector3 targetDirection=(target-transform.position).normalized;
        rb.AddForce(targetDirection * 10); // head towards the target position (10 is its speed)
        rb.MoveRotation(Quaternion.LookRotation(targetDirection)); // look @ the player
    }
}
