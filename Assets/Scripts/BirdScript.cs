using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] obstacles = new GameObject[5];
    [SerializeField] Sprite[] sprites;
    public bool shouldAnimate;
    int spriteChangeFlag = 0;

    void Start()
    {
        shouldAnimate = false;
        obstacles[0] = GameObject.Find("BigCac");
        obstacles[1] = GameObject.Find("smallcac");
        obstacles[2] = GameObject.Find("smallcac2");
        obstacles[3] = GameObject.Find("smallcac3");
        obstacles[4] = GameObject.Find("birddown");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if (spriteChangeFlag < 10 && !player.GetComponent<Player>().isDead && shouldAnimate)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
            spriteChangeFlag++;
        }
        else if (spriteChangeFlag < 20 && !player.GetComponent<Player>().isDead && shouldAnimate)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            spriteChangeFlag++;
        }
        else if (spriteChangeFlag >= 20 && !player.GetComponent<Player>().isDead && shouldAnimate) { spriteChangeFlag = 0; }
        //GameObject player = GameObject.Find("Player");
        //if (player.GetComponent<Player>().isStarted && !player.GetComponent<Player>().isDead)
        //{
        if (!player.GetComponent<Player>().isDead && shouldAnimate) { 
            transform.position = new Vector2(transform.position.x - 0.2f - Obstacle.numObs*0.03f, transform.position.y);
            //}
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<Player>().isDead = true;
        }
        if (collision.gameObject.name == "LeftWall")
        {
            gameObject.GetComponent<BirdScript>().shouldAnimate = false;
            int num = Random.Range(0, 5);
            if (num != 4)
            {
                obstacles[num].GetComponent<Obstacle>().shouldAnimate = true;
            }
            else
            {
                float y = 0f;
                int pos = Random.Range(0, 3);
                switch (pos)
                {
                    case 0:
                        y = 0f;
                        break;
                    case 1:
                        y = 4f;
                        break;
                    case 2:
                        y = 5f;
                        break;
                }
                obstacles[4].transform.position = new Vector2(25f, y);
                obstacles[4].GetComponent<BirdScript>().shouldAnimate = true;
            }
            transform.position = new Vector2(25f, transform.position.y);
            //bool shouldRender = true;
            //int num = Random.Range(0, 5);
            //float y = 0f;
            //switch (num)
            //{
            //    case 0:
            //        y = 0.1f;
            //        break;
            //    case 1:
            //        y = -0.19f;
            //        break;
            //    case 2:
            //        Instantiate(obstacles[1], new Vector2(43f, -0.19f), transform.rotation);
            //        y = -0.2f;
            //        break;
            //    case 3:
            //        y = -0.5f;
            //        break;
            //    case 4:
            //        shouldRender = false;
            //        Instantiate(obstacles[num], new Vector2(19f, 0f), transform.rotation);
            //        break;
            //}
            //if (shouldRender) { Instantiate(obstacles[num], new Vector2(19f, y), transform.rotation); }
            //Destroy(gameObject);
        }
    }
}
