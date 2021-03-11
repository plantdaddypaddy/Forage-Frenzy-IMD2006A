using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 1f;
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

    private void OnCollisionExit(Collision collision)
    {
        ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        

        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            Debug.Log("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jPower);
            ground = false;
        }

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
            transform.RotateAround(transform.position, Vector3.down, 200 * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            transform.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
        }
    }
}
