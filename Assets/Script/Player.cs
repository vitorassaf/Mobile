using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
   

    public static ParticleSystem particle;
    public static ParticleSystem.MainModule m;
    public float timeC;
    public Camera cam;
    public float speed;
    public Rigidbody2D rb2d;
    float horizontalInput;
    public bool grounded;
    public SpriteRenderer sprite;
    public GameObject[] shoots;
    public Transform startR;
    public Transform startL;
    public static Animator anima;
    public bool right;
    public Transform destino;
    public Joystick joystick;


    public static bool podeatirar;
    public static bool esfriar;
    private float tiro = 0;
    public Scrollbar tiromax;
    public int pontos;
    public Text pontuacao;
    public static bool countTime;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        particle = GameObject.FindObjectOfType<ParticleSystem>().GetComponent<ParticleSystem>();
        particle.gameObject.SetActive(false);
        m = particle.main;
        m.startColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        tiromax.size = tiro;
        pontuacao.text = "Pontuação : " + pontos;

        if(esfriar)
        {
            tiro -= Time.deltaTime/10;
           
        }
        if(tiro >= 0.9f)
        {
            podeatirar = false;
            Debug.Log(podeatirar);
        }
        else
        {
            podeatirar = true;
        }
        if (tiro < 0f)
        {
            esfriar = false;
        }
       
        if (Input.GetKey(KeyCode.X))
        {
            
            particle.gameObject.SetActive(true);
            timeC += Time.deltaTime;
            if (timeC >= 2)
            {
                m.startColor = Color.red;
            }
        }
        //if (Input.GetKeyUp(KeyCode.X) && podeatirar)
        // {
        //    particle.gameObject.SetActive(false);
        //   Shoot();
        //   anima.SetTrigger("shoot");
        //   timeC = 0;
        //    m.startColor = Color.green;
        //    esfriar = true;
        //}
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        //horizontalInput = Input.GetAxis("Horizontal");
        //horizontalInput = joystick.Horizontal;

        //rb2d.velocity = new Vector2(horizontalInput * speed, rb2d.velocity.y);
        rb2d.velocity = new Vector2(horizontalInput, rb2d.velocity.y);
        if(joystick.Horizontal >= 0.2f)
        {
            horizontalInput = speed;
        }
        else if  (joystick.Horizontal <= -0.2f)
        {
            horizontalInput = -speed;
        }
        else
        {
            horizontalInput = 0;
          
        }
        if (horizontalInput > 0.2f)
        {
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
            anima.SetBool("run", true);
            sprite.flipX = false;
        }
        else if (horizontalInput < -0.01f)
        {
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
            anima.SetBool("run",true);
            
            sprite.flipX = true;
        }
        else
        {
            horizontalInput = 0;
            //anima.SetFloat("run", Mathf.Abs(horizontalInput));
            anima.SetBool("run",false);
        }
        if (joystick.Vertical >=0.5 && grounded)
        {
            Jump();
        }

        if(countTime)
        {
            timeC += Time.deltaTime;
            if (timeC >= 2)
            {
                m.startColor = Color.red;
            }
        }
        
    }
    public void Jumpbutton()
    {
        if(grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
            grounded = false;
            anima.SetBool("jump", true);
        }
        


    }
    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        grounded = false;
        anima.SetBool("jump", true);
      

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "moeda")
        {
            Destroy(collision.gameObject);
            pontos++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            anima.SetBool("jump", false);
        }
        
        if (collision.gameObject.tag == "inimigo")
        {
            transform.position = destino.transform.position;
        }
        if (collision.gameObject.tag == "Zumbi")
        {
            transform.position = destino.transform.position;
        }
        if (collision.gameObject.tag == "Fim")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Fim");
        }
    }

    public void Shoot()
    {
        if (!sprite.flipX)
        {
            if (timeC < 1)
            {
                Instantiate(shoots[0], startR);
                tiro += 0.1f;
            }

            else if (timeC < 2)
            {
                Instantiate(shoots[1], startR);
                tiro += 0.2f;
            }
                
            else
            {
                Instantiate(shoots[2], startR);
                tiro += 0.3f;
            }
                
        }
        else
        {
            if (timeC < 1)
            {
                Instantiate(shoots[0], startL);
                tiro += 0.1f;
            }

            else if (timeC < 2)
            {
                Instantiate(shoots[1], startL);
                tiro += 0.2f;
            }

            else
            {
                Instantiate(shoots[2], startL);
                tiro += 0.3f;
            }
            
        }
        countTime = false;
        timeC = 0;
    }
    public static void Carregar()
    {
        particle.gameObject.SetActive(true);
        countTime = true;
    }

    public static void Tiro ()
    {
        
            particle.gameObject.SetActive(false);
            anima.SetTrigger("shoot");
            m.startColor = Color.green;
        
       
    }
}
