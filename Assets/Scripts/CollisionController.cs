using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameManagerScript gameManager;
    private bool isDead;
    private bool isWon;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name);
        if ((collision.gameObject?.name.Contains("Enemy") ?? false || collision.gameObject.name.Contains("deathplatform")) && !isDead)
        {
            if (collision.gameObject?.name.Contains("Enemy") ?? false)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null && enemy.isDead)
                {
                    return;
                }
            }


            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }

        if ((collision.gameObject.name.Contains("winobject"))&&!isWon) {
            isWon = true;
            gameObject.SetActive(false);
            gameManager.gameWin();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if ((collision.gameObject?.name.Contains("Enemy") ?? false || collision.gameObject.name.Contains("deathplatform")) && !isDead)
        {
            Debug.Log("here");
            if (collision.gameObject?.name.Contains("Enemy") ?? false)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null && enemy.isDead)
                {
                    return;
                }
            }
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
        if ((collision.gameObject.name.Contains("winobject")) && !isWon)
        {
            isWon = true;
            gameObject.SetActive(false);
            gameManager.gameWin();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if ((collision.gameObject?.name.Contains("Enemy") ?? false || collision.gameObject.name.Contains("deathplatform")) && !isDead)
        {
            if (collision.gameObject?.name.Contains("Enemy") ?? false)
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null && enemy.isDead)
                {
                    return;
                }
            }
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
        if ((collision.gameObject.name.Contains("winobject")) && !isWon)
        {
            isWon = true;
            gameObject.SetActive(false);
            gameManager.gameWin();
        }
    }
}
