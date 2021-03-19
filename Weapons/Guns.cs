using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public class Gun
    {
        public int magazine;
        public int bulletsPerShoot;
        public static float bulletSpeed;
        public GameObject ammo;
        public Vector3 bulletPos;
        public Quaternion bulletRotation = new Quaternion();
        public Animator anim;
        public int maxAmmoInMagazine;
        public int maxAmmo;
        public int currentAmmo;
        public float reloadTime;
        public string nameOfReloadAnimation;
        public SpriteRenderer gunSprite;
        public Color gunColor;

        public void Init(int mag, int bPS, GameObject a, int maxa, float rt, string nORA, Color gC, SpriteRenderer gS, int mA, int cA)
        {
            magazine = mag;
            bulletsPerShoot = bPS;
            ammo = a;
            maxAmmoInMagazine = maxa;
            reloadTime = rt;
            nameOfReloadAnimation = nORA;
            gunSprite = gS;
            gunColor = gC;
            maxAmmo = mA;
            currentAmmo = cA;
            
        }
        public void Shoot()
        {
            
            if (Input.GetMouseButtonDown(0) && magazine > 0 && currentAmmo+magazine > 0)
            {
                
                if (bulletsPerShoot > 1)
                {
                    for (int i = bulletsPerShoot; i > 0; i--)
                    {
                        float randomY = Random.Range(-35, 35);
                        bulletRotation.Set(120, randomY, 0, 0);
                        Instantiate(ammo, bulletPos, bulletRotation);
                    }
                }
                else
                {
                    bulletRotation.Set(0, 0, 0, 0);
                    Instantiate(ammo, bulletPos, bulletRotation);
                }

                magazine--;
                Debug.Log(currentAmmo);
            

            }
        }

        

        
    }

    public static Gun Handgun = new Gun();
    public static Gun Shotgun = new Gun();
    public GameObject handGunBullet;
    public SpriteRenderer gunS;
    public bool isReloading;
    public static int numberOfGun = 1;
    // Start is called before the first frame update
    void Start()
    {
        Handgun.Init(3, 1, handGunBullet, 5, 2, "Reload", new Color (1,1,1,1), gunS, 30, 30);
        Shotgun.Init(3, 5, handGunBullet, 3, 4, "ShotgunReload", new Color(0,0,1,1), gunS, 18, 18);
        
        Handgun.anim = GetComponent<Animator>();
        Shotgun.anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            numberOfGun = 1;
        }else if (Input.GetKeyDown("2"))
        {
            numberOfGun = 2;
        }
        switch (numberOfGun)
        {
            case 1:
                Proccess(Handgun);
                break;
            case 2:
                Proccess(Shotgun);
                break;
        }
        
        
    }
    void Proccess(Gun gun)
    {
        BulletManager.instanceBullet.ChangeBullets(gun.currentAmmo, gun.magazine);
        gun.gunSprite.color = gun.gunColor;
        
        gun.bulletPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        gun.Shoot();
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false && gun.currentAmmo > 0)
        {
            
            isReloading = true;
            StartCoroutine(DoneReloading(gun));
            
            gun.anim.Play(gun.nameOfReloadAnimation);
            Debug.Log("Reloading...");
        }


        
    }
    IEnumerator DoneReloading(Gun gun)
    {
       
        yield return new WaitForSeconds(gun.reloadTime);
        gun.currentAmmo -= (gun.maxAmmoInMagazine - gun.magazine);
        gun.magazine = 0;
        if (gun.currentAmmo < 0) gun.magazine = gun.currentAmmo + gun.maxAmmoInMagazine;
        else gun.magazine = gun.maxAmmoInMagazine;
        if (gun.currentAmmo < 0) gun.currentAmmo = 0;
        gun.anim.Play("Idle");
        Debug.Log("Reloaded");
        isReloading = false;
    }



}
