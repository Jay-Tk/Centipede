using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float centiSpeed = 0.2f;
    FoodPickup foodPickup;
    List<Transform> bodySegments;

    void Start()
    {
        direction = Vector2.right;
        foodPickup = GetComponent<FoodPickup>();
        bodySegments = new List<Transform>();
        bodySegments.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && (direction != Vector2.down))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && (direction != Vector2.up))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && (direction != Vector2.right))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && (direction != Vector2.left))
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        bodySegments = foodPickup.GetBodySegmentList();

        for (int i = bodySegments.Count - 1; i > 0; i--)
        {
            bodySegments[i].position = bodySegments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x + direction.x),
            Mathf.Round(this.transform.position.y + direction.y),
            0.0f
        );

        RotateHead(direction);
    }

    private void RotateHead(Vector2 rawInput)
    {
        if (rawInput == new Vector2(0, 1))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (rawInput == new Vector2(-1, 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (rawInput == new Vector2(0, -1))
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (rawInput == new Vector2(1, 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Body")
        {
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
