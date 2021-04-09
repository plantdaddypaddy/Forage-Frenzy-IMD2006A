using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Vector3 rSpeed;
    public float jPower;
    Vector3 playerV;
    bool ground;
    public GameObject target;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rSpeed = new Vector3(0, 1, 0);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay()
    {
        if (rb.velocity.y < 0) {
            Vector3 vel = rb.velocity;
            vel.y = 0;
            ground = true;
            Debug.Log("GROUNDED");
            new WaitForSeconds(1);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        ground = false;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();

        //new movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            Vector3 jump = new Vector3(0, jPower, 0);
            Debug.Log("Jump");
            rb.AddForce(jump, ForceMode.Impulse);
            ground = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ground = false;
        }

        // old movement
        /*
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Forward");
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Backward");
            transform.Translate(speed * Vector3.back * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            transform.Translate(speed * Vector3.left * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            transform.Translate(speed * Vector3.right * Time.deltaTime);
        }*/
    }
}
