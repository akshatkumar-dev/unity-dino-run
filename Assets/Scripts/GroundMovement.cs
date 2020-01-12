using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numObs = Obstacle.numObs;
        GameObject player = GameObject.Find("Player");
        if (player.GetComponent<Player>().isStarted && !player.GetComponent<Player>().isDead)
        {
            if (transform.position.x <= -36f)
            {
                transform.position = new Vector2(35f, -1.2f);
            }
            else { transform.position = new Vector2(transform.position.x - 0.2f - numObs*0.02f, transform.position.y); }
        }
    }
}
