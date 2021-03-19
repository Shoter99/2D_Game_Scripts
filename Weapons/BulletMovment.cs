using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovment : MonoBehaviour
{
    
    public float bulletSpeed;
    private bool facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        facingLeft = PlayerController.facingLeft;
        if (facingLeft)
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, 180));
        }
    }

    // Update is called once per frame
    void Update()
    {

            
            transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
