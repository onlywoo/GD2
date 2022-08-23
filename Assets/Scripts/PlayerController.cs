using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject player;
    public GameObject bullet;

    public float speed;
    public float playerHealth;
    private float timer;
    public float timeBetweenFiring;

    private Vector2 direction;

    private Camera cam;

    private Vector3 mousePos;

    public Transform bulletTransform;

    public bool canFire;

    public Button increaseFiringSpeed;
    public Button increasePlayerSpeed;
    public Button restartButton;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        Button iFS = increaseFiringSpeed.GetComponent<Button>();
        iFS.onClick.AddListener(IncreaseFiringSpeed);

        Button iPS = increasePlayerSpeed.GetComponent<Button>();
        iPS.onClick.AddListener(IncreasePlayerSpeed);

        Button rB = restartButton.GetComponent<Button>();
        rB.onClick.AddListener(ResetStats);
    }

    void Update()
    {
        ProcessInputs();

        if (playerHealth == 0)
        {
           player.SetActive(false);
        }
        else
        {
            player.SetActive(true);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            playerHealth -= 1;
        }
    }

    void IncreaseFiringSpeed()
    {
        timeBetweenFiring /= 2;
    }

    void IncreasePlayerSpeed()
    {
        speed += 1;
    }

    void ResetStats()
    {
        timeBetweenFiring = 1;
        timeBetweenFiring /= 2;
        speed = 7;
        playerHealth = 3;
    }
}
