using TMPro;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;

    public TextMeshProUGUI timeText;

    public static float maximumVelocity = 10.0f;

    private static float minY = -5.0f;
    private float startTime;
    public bool activeTime;
    private float minutes;
    private float seconds;

    public GameObject GameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeTime = true;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= minY)
        {
            activeTime = false;
            GameOver();
        }

        if (activeTime)
            {
                float time = Time.time - startTime;
                minutes = Mathf.FloorToInt(time / 60);
                seconds = Mathf.FloorToInt(time % 60);
            }


        if (rb.linearVelocity.magnitude >= maximumVelocity)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maximumVelocity);
        }

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }

}