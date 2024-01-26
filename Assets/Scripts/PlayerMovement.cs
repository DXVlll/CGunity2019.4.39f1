using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forwardForce = 2000f;
    [SerializeField] float sidewayForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
    //    rb.AddForce(0, 200, 300);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d")) {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
   //         rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
      //      rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


        if (rb.position.y < -1f)
        {
            UnityEngine.Debug.Log("end");
        }
    }
}
