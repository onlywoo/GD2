using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera cam;

    private Vector3 mousePos;

    private Rigidbody2D body;

    public float bulletSpeed;

    public GameObject bullet;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        body = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        body.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(bullet);
        }

        if (collision.gameObject.name == "Wall")
        {
            Destroy(bullet);
        }

        if (collision.gameObject.name == "Obstacle")
        {
            Destroy(bullet);
        }
    }
}
