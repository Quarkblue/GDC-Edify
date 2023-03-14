using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    private int score_pts = PlayerMovement.score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + score_pts;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + score_pts;
    }
}
