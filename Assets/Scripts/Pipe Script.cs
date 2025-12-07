using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed = 0.75f;
    public float defaultSpeed = 0.75f;


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -3.41f)
        {
            Destroy(gameObject);
        }
    }
    public void IncreaseSpeed()
    {
        if (speed <= 14)
        {
            speed += 0.3f;
        }
        else if (speed >= 25)
        {
            return;
        }
    }
    public void Restart()
    {
        speed = defaultSpeed;
    }
}
