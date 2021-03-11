using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraAI : MonoBehaviour
{
    GameObject target;

    public static Color myColour;
    public static Color spotcolour;
    public Light targetlight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
  
                myColour = Color.red;
  
            
            transform.GetComponent<Renderer>().material.color = myColour;
            targetlight.color = myColour;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

                myColour = Color.white;
            

            transform.GetComponent<Renderer>().material.color = myColour;
            targetlight.color = myColour;
        }

    }

}
