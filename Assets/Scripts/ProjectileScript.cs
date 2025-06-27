using UnityEngine;
using UnityEngine.Rendering;



public class ProjectileScript : MonoBehaviour
{
    public GameObject projectile;
    public GameObject missile;
    public float proj_speed;
    public bool op_missile;

    public void addmissile()
    {
        op_missile = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        op_missile = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (op_missile)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float dirx = transform.position.x - transform.parent.position.x;
                float diry = transform.position.y - transform.parent.position.y;
                float val = Mathf.Sqrt(dirx * dirx + diry * diry);

                float acx = dirx / val;
                float acy = diry / val;
                GameObject proj = Instantiate(missile, transform.position, transform.rotation);
                proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(proj_speed * acx, proj_speed * acy);

                op_missile = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float dirx = transform.position.x - transform.parent.position.x;
                float diry = transform.position.y - transform.parent.position.y;
                float val = Mathf.Sqrt(dirx * dirx + diry * diry);

                float acx = dirx / val;
                float acy = diry / val;
                GameObject proj = Instantiate(projectile, transform.position, transform.rotation);
                proj.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(proj_speed * acx, proj_speed * acy);
            }
        }
    }
}
