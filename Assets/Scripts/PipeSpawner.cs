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
            if (maxTime >= 1.5f)
            {
                maxTime -= 0.3f;
            }
            else if (maxTime < 1.5f && maxTime > 0.3f)
            {
                maxTime -= 0.08f;
            }
            else if (maxTime <= 0.3f)
            {
                maxTime = 0.3f;
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
