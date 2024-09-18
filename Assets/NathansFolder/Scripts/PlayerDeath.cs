using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    string[] deathScenes = new string[3];
    [SerializeField]
    GameObject highscoreCanvas;
    [SerializeField]
    TextMeshProUGUI highscore;
    [SerializeField]
    TextMeshProUGUI highDistance;
    [SerializeField]
    SOScores ScoreSO;
    [SerializeField]
    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //called via events at the different death conditions
    public void PlayerDies(int whatScene)
    {
        StartCoroutine(DeathDelay(whatScene));
    }
    //Coroutine that freezes player, sets high scores, displays highscores waits x seconds, and changes scene
    IEnumerator DeathDelay(int whatScene)
    {
        //freeze player rb
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        //shows highscores
        highscoreCanvas.SetActive(true);
        //changes highscores if score is higher
        if(playerObject.GetComponent<ScoreManager>().score > ScoreSO.HighScore)
        {
            ScoreSO.HighScore = playerObject.GetComponent<ScoreManager>().score;
        }
        if (playerObject.GetComponent<ScoreManager>().distanceInMeters > ScoreSO.HighDistance)
        {
            ScoreSO.HighDistance = playerObject.GetComponent<ScoreManager>().distanceInMeters;
        }
        //changes text to the scores
        highDistance.SetText("Highest Distance: " + ScoreSO.HighDistance);
        highscore.SetText("Highest Score: " + ScoreSO.HighScore);
        //wait
        yield return new WaitForSeconds(5);
        //change to the scene for what death happened
         SceneManager.LoadScene(deathScenes[whatScene]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
