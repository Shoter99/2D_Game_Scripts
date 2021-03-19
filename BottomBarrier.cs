using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarrier : MonoBehaviour
{
    public GameObject playerDeath;
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
        PlayerPrefs.SetInt("Score", 0);
        Destroy(collision.gameObject);
        Invoke(nameof(ReloadMap), 1.5f);
    }
    void ReloadMap()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
