using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f; // Speed at which the balloon moves up
    [SerializeField] float destroyHeight = 10f; // Height at which the balloon gets destroyed
    BalloonSpawner ballonspawner;
    private void Start()
    {
        ballonspawner = FindObjectOfType<BalloonSpawner>();
    }
    void Update()
    {
        // Move the balloon upwards
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        // Check if the balloon is clicked

        // Check if the balloon's position is above the destroy height
        if (transform.position.y > destroyHeight)
        {
            ballonspawner.Health -= 1;
            Destroy(gameObject); // Destroy the balloon game object
        }
    }
    private void OnMouseDown()
    {
        DestroyBalloon();
    }
    void DestroyBalloon()
    {
        BalloonSpawner.Score += 10;
        Destroy(gameObject);
    }
}
