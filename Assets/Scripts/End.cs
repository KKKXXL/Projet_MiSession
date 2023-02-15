using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    public int Score = 1000;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sprite.enabled = false;
            boxCollider.enabled = false;
            GameController.Instance.totalScore += Score;
            GameController.Instance.UpdateTotalScore();
            Destroy(gameObject, 0.2f);
            GameController.Instance.ShowWinPanel();
        }
    }
}
