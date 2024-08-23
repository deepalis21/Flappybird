using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource pause;
    void Start()
    {
        logic =
GameObject.FindGameObjectWithTag("Logic").GetComponent
<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            logic.pauseScreen.SetActive(true);
            logic.angrybirdsongSFX.Stop();
            pause.Play();

        }
        if (Input.GetKeyDown(KeyCode.R) && birdIsAlive)
        {
            Time.timeScale = 1;
            logic.pauseScreen.SetActive(false);
            logic.angrybirdsongSFX.Play();
        }
        if(transform.position.y < -17 || transform.position.y > 17)
        {
            logic.gameOver();
            logic.restartGame();
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
