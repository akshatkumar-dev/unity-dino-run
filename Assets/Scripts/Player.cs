using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int count = 0;
    bool isJump = false;
    public bool isDead = false;
    float goingUp = 0f;
    float comingDown = 0f;
    float intScore = 0f;
    [SerializeField] Text gameOverText;
    [SerializeField] Text score;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject duckPlayer;
   [SerializeField] float lerpTime = 1f;
   [SerializeField] Sprite[] sprites;
    int spriteChangeFlag = 0;
    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        score.text = ("Score: 0");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && isStarted)
        {
            intScore += 0.1f + Obstacle.numObs*0.01f;
            score.text = ("Score: " + Mathf.CeilToInt(intScore));
        }
        if(spriteChangeFlag < 5 && isStarted && !isJump && !isDead)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            spriteChangeFlag++;
        }
        else if(spriteChangeFlag < 10 && isStarted && !isJump && !isDead)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
            spriteChangeFlag++;
        }
        else if(spriteChangeFlag >= 10 && !isDead) { spriteChangeFlag = 0; }
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            isStarted = true;
            isJump = true;
        }
        if (isJump && goingUp <= 1 && !isDead)
        {
            goingUp += Time.deltaTime / lerpTime;
            transform.position = Vector2.Lerp(new Vector2(-10f,0f),new Vector2(-10f, 5f),goingUp);
        }
        else if (isJump && goingUp > 1 && comingDown <= 1 && !isDead)
        {
            comingDown += Time.deltaTime / lerpTime;
            transform.position = Vector2.Lerp(new Vector2(-10f, 5f), new Vector2(-10f, 0f), comingDown);
        }
        if (goingUp > 1 && comingDown > 1 && !isDead)
        {
            goingUp = 0f;
            comingDown = 0f;
            isJump = false;
        }
        if (isDead)
        {
            
            GetComponent<SpriteRenderer>().sprite = sprites[3];
            if (count == 0) { transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y-0.1f); count++; }
            gameOverText.enabled = true;
        }
    }
}
