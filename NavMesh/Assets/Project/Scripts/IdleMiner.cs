using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMiner : MonoBehaviour
{

    Player player;
    public float startTime = 2;
    public float timeBetween;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        timeBetween = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        IdleMineTimer();
    }

    public void IdleMineTimer()
    {

        timeBetween -= Time.deltaTime;

        if (timeBetween <= 0)
        {
            player.minerals++;
            timeBetween = startTime;
        }


    }
}
