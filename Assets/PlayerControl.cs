using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    public int jumpHeight = 8;
    int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                jumpCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            print(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name == "Scene1")
            {
                SceneManager.LoadScene("Scene2");
            }
            else
            {
                SceneManager.LoadScene("Scene1");
            }

        }
    }

}
