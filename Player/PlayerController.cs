using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public GameObject playerDeath;
    public float jumpHeight;
    private bool canJump = true;
    public float speed;
    public GameObject playerBody;
    public static bool facingLeft = false;
    private Animator anim;
    public GameObject coinManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        facingLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (facingLeft)
        {
            horizontal = -horizontal;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontal);
        if(Input.GetKeyDown(KeyCode.A) && facingLeft == false)
        {
            playerBody.transform.Rotate(new Vector2(0, 180));
            facingLeft = true;
        }
        if(Input.GetKeyDown(KeyCode.D) && facingLeft)
        {
            playerBody.transform.Rotate(new Vector2(0, 180));
            facingLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2D.AddForce(transform.up * jumpHeight * 100);

            canJump = false;

        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Terrain")
        {
            CanJump();
        }
    }

    private void OnDestroy()
    {
        Instantiate(playerDeath, transform.position, transform.rotation);
        
    }

    void CanJump()
    {
        canJump = true;
    }
    





}
