using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;

    [SerializeField]
    private float maxY = 0;

    [SerializeField]
    private float minY = 0;

    private float ySpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ySpeed = 0.1f;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < minY)
        {
            ySpeed = speed;
        } else if (transform.position.y > maxY)
        {
            ySpeed = -1 * speed;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + ySpeed, 0);
    }
}
