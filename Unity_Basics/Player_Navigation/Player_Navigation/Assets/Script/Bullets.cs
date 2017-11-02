using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

    public float speed;
    public int damage;

    Vector3 shootDirection;

    void FixedUpdate()
    {
        this.transform.Translate(speed * shootDirection, Space.World);
    }

    public void FireBullets(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
    }

    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(this.gameObject); //one bullets used
    }
}
