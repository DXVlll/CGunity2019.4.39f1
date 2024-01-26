using UnityEngine;

public class PlayerMovementVel : MonoBehaviour
{
    public float speed = 10f; //Controls velocity multiplier

    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script
    Transform t;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
        t = GetComponent<Transform>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        


        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1
        if (xMove != 0 || zMove != 0) {
            
                 Vector3 offset = t.forward * zMove * speed + t.right * xMove * speed;
                rb.AddForce(offset, ForceMode.VelocityChange);
        }


    }
}