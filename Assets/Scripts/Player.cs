using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float jump;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    AudioClip lose_clip; 

    [SerializeField]
    AudioClip jump_clip;

    Rigidbody2D rb;
    Animator anim;
    public int counter = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0,jump);
            // playing jump clip
            GetComponent<AudioSource>().PlayOneShot(jump_clip);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "GameOver")
        {
            // stop the game
            Time.timeScale = 0;
            // loading gameover panel
            gameOver.SetActive(true);
            // plaing lose clip
            GetComponent<AudioSource>().PlayOneShot(lose_clip);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("passing"))
        {
            counter++;
            //Debug.Log(counter);
            scoreText.text = counter.ToString();
            Destroy(collision.gameObject,2);
        }
    }


    // change the scene 
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
