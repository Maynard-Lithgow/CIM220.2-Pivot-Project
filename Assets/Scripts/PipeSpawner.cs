using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public float defaultMaxTime = 4f;
    public float heightRange = 1.5f;
    public GameObject pipePrefab;
    public PipeScript pipeScript;

    public float maxTime = 4f;
    public float timer;
    void Start()
    {
        pipeScript.speed = pipeScript.defaultSpeed;
        SpawnPipe();

    }
    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            if (maxTime >= 2f)
            {
                maxTime -= 0.45f;
            }
            else if (maxTime < 1.99f && maxTime > 0.9f)
            {
                maxTime -= 0.3f;
            }
            else if (maxTime <= 0.9 && maxTime > 0.41f)
            {
                maxTime -= 0.09f;
            }
            else if (maxTime <= 0.6f)
            {
                maxTime = 0.6f;
            }
            timer = 0;
        }

        timer += Time.deltaTime; 
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        pipeScript.IncreaseSpeed();

    }
    public void Restart()
    {
        maxTime = defaultMaxTime;
    }
}
