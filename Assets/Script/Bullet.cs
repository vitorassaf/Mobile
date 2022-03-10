using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool dir;
    public Player player;
    SpriteRenderer sprite;
    private float altura;
    // Start is called before the first frame update
    void Start()
    {
        altura = transform.position.y;
        player = FindObjectOfType<Player>();
        dir = !player.sprite.flipX;
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = !dir;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dir)
        {
            transform.position = new Vector2(transform.position.x + .25f, altura);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - .25f, altura);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "porta")
        {
            Destroy(collision.gameObject);
        }
    }
 
}
