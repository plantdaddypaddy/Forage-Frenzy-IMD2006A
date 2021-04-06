using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 7f;
    public Vector3 rSpeed;
    public float jPower = 2000;
    Vector3 playerV;
    bool ground;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rSpeed = new Vector3(0, 1, 0);
        
    }

    private void OnCollisionStay()
    {
        ground = true;
    }

    /*private void OnCollisionEnter() 
    {
        ground = true;
    }*/

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
            Debug.Log("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jPower);
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
