using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    //public static Shoot Instance;
    public GameObject gunPivot;
    public SpriteRenderer playerSprite;
    public SpriteRenderer gunSprite;
    public GameObject bullet;
    public GameObject muzzle;
    public static float bulletSpeed = 35f;
    public static float bulletDamage = 30f;
    Vector3 dir;
    float angle ;
    float timer = 0.2f;
    float tempTimer;
    void Start()
    {
        //Instance = this;
        tempTimer = timer;
    }

    void Update()
    {
        LookAtMouse();
        Shot();
    }

    void LookAtMouse()
    {
        if(angle < -90 || angle > 90)
        {
            gunPivot.transform.localPosition = new Vector3(-1.05f, -0.38f, 0);
            gunSprite.flipY = true;
            playerSprite.flipX = true;
        }
        else if(angle > -90 || angle < 90)
        {
            gunPivot.transform.localPosition = new Vector3(1.05f, -0.38f, 0);
            playerSprite.flipX = false;
            gunSprite.flipY=false;
        }
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gunPivot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shot()
    {
        tempTimer-=Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            if(tempTimer<=0f)
            {
                GameObject ballInstance = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
                tempTimer=timer;
            }
        }
    }
}
