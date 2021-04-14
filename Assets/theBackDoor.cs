using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theBackDoor : MonoBehaviour
{

    public GameObject trigger;
    public GameObject lDoor;

    Animator leftAnim;


    // Start is called before the first frame update
    void Start()
    {
        leftAnim = lDoor.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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

    }
}