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
        transform.LookAt(target.transform);
    }

    private void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Distance");
            target2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Debug.Log("Distance2");
            target2.gameObject.SetActive(false);
        }
    }
}
