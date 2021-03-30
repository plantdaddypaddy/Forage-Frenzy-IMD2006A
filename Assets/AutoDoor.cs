using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{

    public GameObject movingDoor;
    public float maxOpening = 193f;
    public float maxClosing = 190f;
    public float speed;
    bool playerHere;
    // Start is called before the first frame update
    void Start()
    {
        playerHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHere)
        {
            if(movingDoor.transform.position.x < maxOpening)
            {
                movingDoor.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }
        }
        else
        {
            if (movingDoor.transform.position.x > maxClosing)
            {
                movingDoor.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHere = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;

        }
    }
}
