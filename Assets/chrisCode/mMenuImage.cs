using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mMenuImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform canvasS = GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        transform.localScale = canvasS.localScale * 2;


        Vector3 mousePos = Input.mousePosition;

        transform.position = transform.position + (mousePos - transform.position) * 0.01f;

        float mouseX = mousePos.x;
        float mouseY = mousePos.y;
        float screenX = Screen.width;
        float screenY = Screen.height;

        if (mouseX < 0 || mouseX > screenX || mouseY < 0 || mouseY > screenY)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
