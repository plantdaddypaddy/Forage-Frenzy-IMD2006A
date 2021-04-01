using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depositDisappear : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Poop");
            target2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Poop2");
            target2.gameObject.SetActive(false);
        }
    }
}
