using UnityEngine;

public class MiniGamer : MonoBehaviour
{
    public GameObject FlapBehaviour;
    public PipeSpawner pipeSpawner;
    public PipeScript pipeScript;

    public Canvas gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        //Debug.Log("Game over triggered");
        gameOver.enabled = true;
    }
    public void RestartGame()
    {
        FlapBehaviour.transform.position = new Vector3(-0.14f, -2.42f, -2.73f);
        pipeSpawner.Restart();
        pipeScript.Restart();

        gameOver.enabled = false;
    }
}
