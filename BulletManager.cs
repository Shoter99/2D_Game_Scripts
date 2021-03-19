using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BulletManager : MonoBehaviour
{
    public int ammo = 0;
    public int maxammo = 0;
    public static BulletManager instanceBullet;
    public TextMeshProUGUI bulletText;
    // Start is called before the first frame update
    void Start()
    {
        if (instanceBullet == null)
        {
            instanceBullet = this;
        }
        bulletText.text = "Ammo: " + ammo.ToString() + "/" + maxammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeBullets(int ma, int a)
    {
        maxammo = ma;
        ammo = a;
        bulletText.text = "Ammo: " + ammo.ToString() + "/" + maxammo.ToString();
    }
}
