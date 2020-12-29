using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static readonly float JUMP_HEIGHT = 8.0f;
    private static readonly float RUNNING_SPEED = 2.0f;

    private bool jumpKeyPressed = false;
    private float horizontalMovement = 0;
    private Rigidbody rigidbodyComponent;
    private int coins = 0;
    private int deaths = 0;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private Transform groundCheckTransform = null;

    [SerializeField]
    private LayerMask playerMask;

    [SerializeField]
    private Text txtCoin;

    [SerializeField]
    private Text txtDeaths;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // && GetComponent<Rigidbody>().velocity.y == 0
        {
            jumpKeyPressed = true;
        }

        horizontalMovement = Input.GetAxis(Constants.AXIS_HORIZONTAL) * RUNNING_SPEED;
    }

    private void FixedUpdate()
    {
        bool isGrounded = Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0;

        if (jumpKeyPressed && isGrounded)
        {
            rigidbodyComponent.AddForce(Vector3.up * JUMP_HEIGHT, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalMovement,
            rigidbodyComponent.velocity.y,
            0);

        // Move back to start if falls through the floor
        if (rigidbodyComponent.position.y < Constants.BEDROCK_Y)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Constants.COIN_LAYER)
        {
            Destroy(other.gameObject);
            coins++;
            txtCoin.text = string.Format("Coins: {0}", coins);
        }
        if (other.gameObject.layer == Constants.ENEMY_LAYER)
        {
            Die();
        }
    }

    private void Die()
    {
        rigidbodyComponent.position = new Vector3(spawnPoint.transform.position.x - 2,
            spawnPoint.transform.position.y + 2, spawnPoint.transform.position.z);
        rigidbodyComponent.velocity = Vector3.zero;
        deaths++;
        txtDeaths.text = string.Format("Deaths: {0}", deaths);
    }
}
