using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Paddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5.0f;
    private float movementDirection;
    private float maxPos = 8.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveComp();   
    }

    void MoveComp()
    {
        movementDirection = Input.GetAxis("Horizontal");
        if ( (movementDirection > 0 && transform.position.x <= maxPos) || (movementDirection < 0 && transform.position.x >= -maxPos) ) {
            transform.position += Vector3.right * movementDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
