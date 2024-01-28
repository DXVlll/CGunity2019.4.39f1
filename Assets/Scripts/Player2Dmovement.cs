using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Dmovement : MonoBehaviour
{
    [SerializeField] bool moveRight = false;
    [SerializeField] bool moveLeft = false;
    [SerializeField] bool moveUp = false;
    [SerializeField] bool moveDown = false;

    [SerializeField] float jumpStrength = 1f;
    [SerializeField] float speed = 1f;
    private Transform playerTransform;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        moveRight = Input.GetKey(KeyCode.D);
        moveLeft = Input.GetKey(KeyCode.A);
        moveDown = Input.GetKey(KeyCode.S);
        moveUp = Input.GetKey(KeyCode.W);

        if (moveRight)
        {
            playerTransform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }
        if (moveLeft)
        {
            playerTransform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }
        if (moveUp)
        {
            Vector3 offset = new Vector3(0, 1*jumpStrength, 0);
            playerRB.AddForce(offset, ForceMode.Impulse);
        }



    }
}
