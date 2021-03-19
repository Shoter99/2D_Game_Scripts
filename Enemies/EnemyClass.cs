using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public class Enemy
    {
        public int healthPoints;
        public float attackPower;
        public float speed;

        public GameObject deathParitcles;

        public void Init(int hp, float aP, float s, GameObject dP)
        {
            healthPoints = hp;
            attackPower = aP;
            speed = s;
            deathParitcles = dP;
        }

    }
}
