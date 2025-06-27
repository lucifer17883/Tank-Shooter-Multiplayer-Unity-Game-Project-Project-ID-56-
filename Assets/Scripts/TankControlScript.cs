using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TankControlScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float acceleration;
    public float max_speed;
    public float speed = 0;
    public float ang_speed = 100;
    public float angle;
    public int health = 3;
    public float barrel_angle = 0;
    public float barrel_ang_speed = 50;
    public Rigidbody2D tank_whole;
    public ProjectileScript bullet;
    public GameObject barrel;
    public int timer = 0;
   
    void Start()
    {
        health = 3;
        bullet = GameObject.FindGameObjectWithTag("Bullet").GetComponent<ProjectileScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Projectile")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "Missile")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "OP")
        {
            bullet.addmissile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        angle = gameObject.transform.eulerAngles.z * Mathf.Deg2Rad; ;
        if (Input.GetKey(KeyCode.W))
        {
            if(speed < max_speed)
            {
                speed += acceleration * Time.deltaTime;
                tank_whole.linearVelocity = new Vector2((-1) * speed * Mathf.Sin(angle), speed * Mathf.Cos(angle));
            }
            else
            {
                tank_whole.linearVelocity = new Vector2((-1) * speed * Mathf.Sin(angle), speed * Mathf.Cos(angle));
            }
        }
        else
        {
            if(speed > 0)
            {
                speed -= acceleration * Time.deltaTime;
                tank_whole.linearVelocity = new Vector2((-1) * speed * Mathf.Sin(angle), speed * Mathf.Cos(angle));
            }
        }

        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == false)
        {
            
                tank_whole.angularVelocity = ang_speed;
            
        }

        else if(Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == true)
        {
           
                tank_whole.angularVelocity = -ang_speed;
            
        }

        else if((Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == true) || (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false))
        {
            tank_whole.angularVelocity = 0;
        }
        float y = transform.position.y;
        float x = transform.position.x;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            barrel.transform.RotateAround(new Vector3(x,y,0),new Vector3(0,0,1), barrel_ang_speed * Time.deltaTime);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            barrel_angle -= barrel_ang_speed * Time.deltaTime;
            barrel.transform.RotateAround(new Vector3(x, y, 0), new Vector3(0, 0, 1),(-1)* barrel_ang_speed * Time.deltaTime);
        }
    }
}
