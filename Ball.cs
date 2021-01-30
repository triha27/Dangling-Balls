using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //public ParticleSystem particleEffect;
    private Rigidbody2D ballRb;
    private GameObject player;
    private Vector3 forceDirection;
    private GameManager GameManager;
    private float speed = 0.75f;
    private Vector2 movement;
    private int lifeCounter = 2;
    public GameObject effect; 
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 0.5f);
        //particleEffect.gameObject.transform.position = transform.position;

        ballRb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        player = player.transform.GetChild(0).gameObject;
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //effect = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = player.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(forceDirection.y, forceDirection.x) * Mathf.Rad2Deg;
        ballRb.rotation = angle;
        forceDirection.Normalize();
        movement = forceDirection;
        ballRb.AddForce(forceDirection * speed);
    }
    void FixedUpdate()
    {
        MoveBall(movement);
    }
    void MoveBall(Vector2 direction)
    {
        ballRb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    void PlayEffect()
    {
        Debug.Log("I am playing effect");
        Instantiate(effect,transform.position,transform.rotation);
        //effect.Play();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayEffect();

        // effect.GetComponent
        if (other.gameObject.CompareTag(this.tag))
        {
            //particleEffect.Play();
            // GameManager.DisplayScore(30);  
        }
        else
        {
            // Debug.Log("lifeCounter" + lifeCounter);
            GameManager.ReduceLife();
            Debug.Log(lifeCounter);
            // GameManager.DisplayScore(-5);
        }
        //Debug.Log("other :"+other.gameObject.tag+"ball"+this.tag);
        // effect.SetActive(true);
        Destroy(this.gameObject);


    }
}
