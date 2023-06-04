using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 2f;
    public float chaseDistance = 5f;

    private Vector3 startPosition;
    private Vector3 initialScale;
    private float previousPosition;
    private float direction;
    private GameObject player;
    private bool isChasing;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        initialScale = transform.localScale;
        previousPosition = transform.position.x;
        player = GameObject.Find("Player");
        isChasing = false;
        startTime = Time.time;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < chaseDistance)
        {
            if (!isChasing)
            {
                isChasing = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), speed * Time.deltaTime);

            if (transform.position.x < player.transform.position.x && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
            }
            else if (transform.position.x > player.transform.position.x && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
            }
        }
        else
        {
            if (isChasing)
            {
                startPosition = transform.position;
                previousPosition = transform.position.x;
                startTime = Time.time;
                isChasing = false;
            }

            float newPosition = Mathf.PingPong((Time.time - startTime) * speed, distance);
            direction = startPosition.x + newPosition - previousPosition;

            if (direction > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
            }
            else if (direction < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z);
            }

            transform.position = startPosition + new Vector3(newPosition, 0, 0);
            previousPosition = transform.position.x;
        }
    }
}
