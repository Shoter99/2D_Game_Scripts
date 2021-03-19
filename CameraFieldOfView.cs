using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldOfView : MonoBehaviour
{
    public Camera camera;
    bool wide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camera.fieldOfView = 100.0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camera.fieldOfView = 73.3f;
        }
    }
}
