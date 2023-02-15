using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitItem : MonoBehaviour
{
    public GameObject collectedEffect;
    public int Score = 100;
    private SpriteRenderer sprite;
    private CircleCollider2D circleCollider;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sprite.enabled = false;
            circleCollider.enabled = false;

            collectedEffect.SetActive(true);

            GameController.Instance.totalScore += Score;
            GameController.Instance.UpdateTotalScore();
            Destroy(gameObject, 0.2f);
        }
    }
}
