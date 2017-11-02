using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 3;

    void CollidedWithEnemy(Enemy enemy)
    {
  
        enemy.Attack(this);
  
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            CollidedWithEnemy(enemy);
        }
    }


}
