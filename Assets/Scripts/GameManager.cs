using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.GetComponent<Player>().isDead && Input.GetKey(KeyCode.Space))
            SceneManager.LoadScene("SampleScene");
    }
}
