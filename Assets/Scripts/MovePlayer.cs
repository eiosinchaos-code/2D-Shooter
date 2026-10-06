using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        // Get input from horizontal and vertical axes (supports arrow keys and WASD by default)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Move the GameObject smoothly based on frame time
        transform.Translate(new Vector3(moveX, moveY, 0f));

        // MOVED HERE: Keep the player inside the camera bounds every frame
        //Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
        //viewPortPosition.x = Mathf.Clamp01(viewPortPosition.x);
        //viewPortPosition.y = Mathf.Clamp01(viewPortPosition.y);
        //transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left / 2);
        Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up / 2);


        // Handle shooting when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
        }
        float deltaX = viewPortPosition.x - viewPortXDelta.x;
        float deltaY = -viewPortPosition.y + viewPortYDelta.y;
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0 + deltaY, 1 - deltaY);
        transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
    }
}