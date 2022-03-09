using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100;
    public GameObject Racket;
    public Vector3 start_position;
    bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float ball_y = transform.position.y;
        float racket_y = Racket.transform.position.y;

        if(ball_y < racket_y - 20 && reset == false)
        {
            reset = true;
            StartCoroutine(Reset());
        }
        
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);
        transform.position = start_position;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        reset = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Racket")
        {
            float ball_x = transform.position.x;
            float racket_x = col.transform.position.x;
            float racket_w =col.collider.bounds.size.x;

           //direction_x = 1 move to right
           //direction_x = -1 move to left
           //direction_x = 0 dont right

           float direction_x = (ball_x - racket_x) / racket_w;
           GetComponent<Rigidbody2D>().velocity =  new Vector2(direction_x, 1) * speed;

        }
        else
        {
           

        }
    }
}
