using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> balls;
    private GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.gameActive = true;
        StartCoroutine(generateBalls());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator generateBalls()
    {
        Debug.Log("we came to generate balls");
        Debug.Log("Game Manager"+ gameManager.gameActive);
        while (gameManager.gameActive == true)
        {
            Debug.Log("we are waiting for them to generate");
            yield return new WaitForSecondsRealtime(5.0f);
            int randomNum = GetRandomBall();
            GenerateAddForce(randomNum);
        }
    }

    int GetRandomBall()
    {
        return Random.Range(0, balls.Count);
    }
    Vector3 GetRandomLocation()
    {
        float x = Random.Range(-6f, -0f);
        float[] yValues = {-1.5f, 1.25f};
        float yValue = yValues[Random.Range(0,yValues.Length)];
        return new Vector3(x, yValue, 0);

    }
    void GenerateAddForce(int randomNum)
    {
        GameObject ball = balls[randomNum];
        
        Instantiate(ball, GetRandomLocation(), ball.transform.rotation);
        
    }
}
