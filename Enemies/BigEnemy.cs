using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    
    private Vector2 pos;
    private Quaternion rot;
    public GameObject enemyToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        rot = gameObject.transform.rotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FireBall")
        {
            pos.x += 1.0f;

            Instantiate(enemyToSpawn, pos, rot);
            pos.x -= 3.0f;
            Instantiate(enemyToSpawn, pos, rot);
        }
    }
}
