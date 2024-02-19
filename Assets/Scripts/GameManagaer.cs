using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab; // Prefab of the balloon
    public float startX = -5f; // Starting X position
    public float rangeX = 10f; // Range of X positions
    public float initialMoveSpeed = 5f; // Initial speed of balloons
    public float initialSpawnInterval = 2f; // Initial time between spawns
    public float speedIncreaseRate = 0.1f; // Rate at which speed increases over time
    public float spawnIntervalDecreaseRate = 0.1f; // Rate at which spawn interval decreases over time
    public float maxSpeed = 20f; // Maximum speed of balloons
    public float minSpawnInterval = 0.5f; // Minimum time between spawns
    public Color[] balloonColors = { Color.red, Color.green, Color.blue, Color.yellow,Color.black,Color.white,Color.cyan }; // Array of balloon colors
    public static int Score = 0;
    public float Health = 3;
    private float currentMoveSpeed;
    private float currentSpawnInterval;
    private float timeSinceLastSpawn;
    public float zpos=141f;
    int i = 0;
    public TextMeshProUGUI scoreboard;
    public TextMeshProUGUI timerText;
    public float gameTime = 60f; // Total game time in seconds
    private float timer; // Current time remaining
    menumanager mnu;
    bool gameended = false;
    //sPlayfabManager m_PlayfabManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        currentMoveSpeed = initialMoveSpeed;
        currentSpawnInterval = initialSpawnInterval;
        timeSinceLastSpawn = 0f;
        mnu=FindObjectOfType<menumanager>();
    }

    void Update()
    {
        if(gameended) return;
        timeSinceLastSpawn += Time.deltaTime;
        gameTime -= Time.deltaTime;
        timerText.text = "Timer: " + gameTime.ToString("F2");
        scoreboard.text = "Score: " + Score;
        if (gameTime < 0)
        {

            SceneManager.LoadScene(2);
            gameended = true;
        }
        if (timeSinceLastSpawn >= currentSpawnInterval)
        {
            SpawnBalloon();
            timeSinceLastSpawn = 0f;
        }

        UpdateSpeedAndSpawnInterval();
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(startX, startX + rangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, zpos);
        GameObject newBalloon = Instantiate(balloonPrefab, spawnPosition, Quaternion.identity);

        // Randomly select a color from the balloonColors array
        Color randomColor = balloonColors[i];
        i++;
        if (i == balloonColors.Length) i = 0;

        // Apply the random color to the balloon's material
        Renderer balloonRenderer = newBalloon.GetComponent<Renderer>();
        if (balloonRenderer != null)
        {
            balloonRenderer.material.color = randomColor;
        }

        newBalloon.GetComponent<Balloon>().moveSpeed = currentMoveSpeed;
    }

    void UpdateSpeedAndSpawnInterval()
    {
        // Increase speed
        currentMoveSpeed = Mathf.Min(currentMoveSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

        // Decrease spawn interval
        currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseRate * Time.deltaTime, minSpawnInterval);
    }
}
