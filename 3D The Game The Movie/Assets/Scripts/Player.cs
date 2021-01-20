using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;

//FOR OG CANVAS
    //public Text points;
   // public Text hp;

    public int health = 3;
    public int score = 0;
    public UIsch ui;

    private bool isGrounded;

    public int GetHealth()
    {
        return health;
    }
    public void Hurt()
    {
        health--;
        //ShowHp(); FOR OG CANVAS
    }

//USED FOR ORIGINAL CANVAS
    //public void ShowHp()
    //{
    //    hp.text = "HP: " + health.ToString();
    //}
    //public void ShowScore(int score)
    //{
    //    points.text = "Score: " + score.ToString();
    //}
    // Update is called once per frame


    void Update()
    {
        // get hor and vert inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // set the vel based on inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // create a copy of out vel variable and set the Y axis to 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // if were moving rotate to face moving direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
       // ShowScore(score); FOR OG CANVAS
        Debug.Log(score);

        ui.SetScoreText(score);
    }
}
