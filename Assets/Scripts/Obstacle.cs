using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameObject[] obstacles = new GameObject[5];
    public static int numObs = 0;
    public bool shouldAnimate;
    // Start is called before the first frame update
    void Start()
    {
        shouldAnimate = false;
        if (gameObject.name=="FakeObject") { shouldAnimate = true; }
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
        if (shouldAnimate && player.GetComponent<Player>().isStarted && !player.GetComponent<Player>().isDead)
        {
            transform.position = new Vector2(transform.position.x - 0.2f -numObs*0.02f, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.name != "FakeObject")
        {
            GameObject.Find("Player").GetComponent<Player>().isDead = true;
        }
        if (collision.gameObject.name == "LeftWall")
        {
            numObs++;
            gameObject.GetComponent<Obstacle>().shouldAnimate = false;
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
                            y = 2f;
                            break;
                        case 2:
                            y = 4f;
                            break;
                    }
                    obstacles[4].transform.position = new Vector2(25f, y);
                    obstacles[4].GetComponent<BirdScript>().shouldAnimate = true;
                }
            transform.position = new Vector2(25f, transform.position.y);
        }


    }
}
