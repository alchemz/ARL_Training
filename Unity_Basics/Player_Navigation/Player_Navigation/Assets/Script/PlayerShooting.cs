using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Bullets bulletsPrefab;
    public LayerMask mask;

    
    void Shoot(RaycastHit hit)
    {
        var bullets = Instantiate(bulletsPrefab).GetComponent<Bullets>();
        Debug.Log("Create Bullets!");
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);

        var direction = pointAboveFloor - transform.position;

        var shootRay = new Ray(this.transform.position, direction);
        Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.green, 2);

        Physics.IgnoreCollision(GetComponent<Collider>(), bullets.GetComponent<Collider>());

        bullets.FireBullets(shootRay);
    }

    void RaycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

        if(Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            Shoot(hit);
            Debug.Log("Shoot!");
        }
    }

    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            RaycastOnMouseClick();
            Debug.Log("click!");
        }
    }
}
