using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D playerRb;
    private Quaternion targetRotation;
    public TextMeshProUGUI timeText;
    public List<Image> lifes;
    private int timer = 0;
    // private int score = 0;
    private float smooth = 1.0f;
    private int lifeCounter = 2;
    public bool gameActive {get;set;}
    // Start is called before the first frame update
    void Start()
    {
        // playerRb = Player.GetComponent<Rigidbody2D>();
        gameActive = true;
        targetRotation = transform.rotation;
        StartCoroutine(TimeUpdate());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator TimeUpdate()
    { 
        while(gameActive)
        {
        Debug.Log("Do i start");
        yield return new WaitForSeconds(1.0f);
        timeText.text = "Time : "+ timer;
        timer++;
        }
    }
    // public void DisplayScore(int points)
    // {
    //     score += points;
    //     scoreText.text = "Score :" + score;
    //     //Debug.Log(score);
    // }
    public void ReduceLife()
    {
        if(lifeCounter == 0)
        {
            gameActive = false;
        }
        Debug.Log("Destroying life");
        lifes[lifeCounter].GetComponent<Image>().enabled = false;
        lifeCounter--;
        
        // lifes.RemoveAt(lifes.Count-1);
    }
    public void ChangePlayerRotation(string direction)
    {

        Debug.Log("Changing rotation to " + direction);
        if (direction.Equals("left"))
        {
            // foreach(Rigidbody2D Rb in playerRb)
            // playerRb.AddTorque(5.0f);
            targetRotation *= Quaternion.AngleAxis(20, Vector3.forward);
            Player.transform.rotation = Quaternion.Lerp(targetRotation, targetRotation, 10 * smooth * Time.deltaTime);
        }
        else if (direction.Equals("right"))
        {
            // foreach(Rigidbody2D Rb in playerRb)
            // playerRb.AddTorque(-5.0f);
            targetRotation *= Quaternion.AngleAxis(-20, Vector3.forward);
            Player.transform.rotation = Quaternion.Lerp(targetRotation, targetRotation, 10 * smooth * Time.deltaTime);
        }

    }

}
