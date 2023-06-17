using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameManagerScript gameManager;
    private bool isDead;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy_1" && !isDead) {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy_1" && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy_1" && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }
}
