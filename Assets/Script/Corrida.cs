using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrida : MonoBehaviour
{

   public bool direcao;
    public float speed;
    private SpriteRenderer flip;
    void Start()
    {
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (direcao)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            flip.flipX = true;
        }
        else
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            flip.flipX = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Direcao")
        {
            direcao = !direcao;
        }
    }

}

