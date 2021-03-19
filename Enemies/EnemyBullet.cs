using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    private float posX;
    bool go = true;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x - 20;
        //InvokeRepeating("ScaleDown", 1.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
        }
        
        
        if (transform.position.x <= posX)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerPrefs.SetInt("Score", 0);
            Destroy(collision.gameObject);
            go = false;
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(LoadLevel());
        }
        /*if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
    }
    public static IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(Application.loadedLevel);
    }
    /*void ScaleDown()
    {
        if (transform.localScale.x >= 0)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }*/
}
