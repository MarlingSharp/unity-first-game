using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minY;

    private float ySpeed;

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
