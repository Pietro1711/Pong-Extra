using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBewegung : MonoBehaviour
{

    private Rigidbody2D rb;

    public GameObject Spieler1;
    public GameObject Spieler2;
    public float acceleration = 1f;




    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        Spieler1 = GameObject.Find("Spieler 1");
        Spieler2 = GameObject.Find("Spieler 2");

        Punktezähler.canAddScore = true;
        StartCoroutine(Pause());

    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(this.transform.position.x) >= 21f)
        {

            Punktezähler.canAddScore = true;

            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
            acceleration = 1f;
        }


    }

    IEnumerator Pause()
    {


        float directionyY = Random.Range(-1f, 1f);
        float directionX = directionyY * 2f; 



        if (directionX == 0)
        {
            directionX = 1;
        }


        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(directionX, directionyY).normalized * 8f;
    }


    void OnCollisionEnter2D(Collision2D hit)
    {

        if (hit.gameObject.tag == "Spieler")
        {
            if (hit.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), 8f) * 1.1f;
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), 8f) * 1.1f;
            }
            else if (hit.gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.5)
            {
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), -8f) * 1.1f;
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), -8f) * 1.1f;
            }
            else
            {
                if (this.transform.position.x < 0) rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), 0f) * 1.1f;
                else rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), 0f) * 1.1f;
            }
            acceleration += 0.2f;
        }




    }
}
