using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyDeathParticles;
    public GameObject bullet;
    private Vector2 pos;
    public SpriteRenderer enemySprite;
    public SpriteRenderer enemyarmSprite;
    public ParticleSystem enemyParticle;
    public static bool moveLeft = false;
    public GameObject arm;
    public float speed;
    float r, g, b;
    // Start is called before the first frame update
    void Start()
    {
        /*r = Random.Range(0, 100);
        g = Random.Range(0, 100);
        b = Random.Range(0, 100);
        enemySprite.color = new Color(r/100, g/100, b/100);
        enemyarmSprite.color = new Color((r / 100)-0.1f, (g / 100)-0.1f, (b / 100)-0.1f);*/
        //InvokeRepeating("Shoot", 2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {


        pos = arm.transform.position;
        transform.Translate(Vector2.left * Time.deltaTime * speed);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            if (moveLeft)
            {
                transform.Rotate(new Vector2(0, 180));
                moveLeft = false;
            }
            else
            {
                transform.Rotate(new Vector2(0, 180));
                moveLeft = true;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (moveLeft)
            {
                transform.Rotate(new Vector2(0, 180));
                moveLeft = false;
            }
            else
            {
                transform.Rotate(new Vector2(0, 180));
                moveLeft = true;
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Score", 0);
            StartCoroutine(EnemyBullet.LoadLevel());
            Destroy(collision.gameObject);

        }

    }
    private void Shoot()
    {
        
        Instantiate(bullet, pos, transform.rotation);
    }

}
