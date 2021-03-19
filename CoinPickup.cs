using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPickup : MonoBehaviour
{
    public int value = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            CoinManager.instance.ChangeValue(value);
            
        }
        
    }
}
