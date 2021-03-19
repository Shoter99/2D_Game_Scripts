using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
    public GameObject iceParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1.0f);
        Instantiate(iceParticles, gameObject.transform.position, gameObject.transform.rotation);
    }
}
