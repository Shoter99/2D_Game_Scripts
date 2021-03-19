using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitter : MonoBehaviour
{
    EnemyClass.Enemy bitter = new EnemyClass.Enemy();
    public GameObject enemyDeathParticles;
    Vector2 pos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bitter.Init(2, 2, speed, enemyDeathParticles);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        transform.Translate(Vector2.left * Time.deltaTime * bitter.speed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            transform.Rotate(new Vector2(0, 180));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.Rotate(new Vector2(0, 180));
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Score", 0);
            StartCoroutine(EnemyBullet.LoadLevel());
            Destroy(collision.gameObject);

        }

    }
    private void OnDestroy()
    {
        Instantiate(bitter.deathParitcles, transform.position, transform.rotation);
    }
}
