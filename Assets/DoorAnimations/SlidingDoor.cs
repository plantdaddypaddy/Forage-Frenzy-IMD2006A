using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    public GameObject trigger;
    public GameObject lDoor;
    public GameObject rDoor;

    Animator leftAnim;
    Animator rightAnim;

    // Start is called before the first frame update
    void Start()
    {
        leftAnim = lDoor.GetComponent<Animator>();
        rightAnim = rDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SlideDoors(true);
        }
        else if (other.gameObject.tag == "Guard")
        {
            SlideDoors(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SlideDoors(false);
        }
        else if (other.gameObject.tag == "Guard")
        {
            SlideDoors(false);
        }
    }

    void SlideDoors(bool state)
    {
        leftAnim.SetBool("slide", state);
        rightAnim.SetBool("slide", state);
    }
}
