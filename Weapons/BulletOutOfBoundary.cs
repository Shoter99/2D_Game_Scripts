using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOutOfBoundary : MonoBehaviour
{
    private float startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startingPos + 20.0f)
        {
            Destroy(gameObject);
        }
    }
}
