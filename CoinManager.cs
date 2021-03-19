using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public int coins = 0;
    public static CoinManager instance;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            coins = PlayerPrefs.GetInt("Score");
        }
        if(instance == null)
        {
            instance = this;
        }
        text.text = "Coins: " + coins.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ChangeValue(int numOfCoins)
    {
        coins += numOfCoins;
        text.text = "Coins: " + coins.ToString();
        Debug.Log(coins);
        PlayerPrefs.SetInt("Score", coins);
    }
}
