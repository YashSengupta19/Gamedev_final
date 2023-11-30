using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    float moveForce = 10f;
    public float powerUpDuration = 5f;
    private bool isPowerUpActive = false;
    private bool onlyOnce = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha9) && onlyOnce)
        {
            ActivatePowerUp();
        }

        if (isPowerUpActive)
        {
            // Move the player continuously during the power-up
            float movementX = Input.GetAxisRaw("Horizontal");
            float movementY = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(movementX, movementY, 0f) * Time.unscaledDeltaTime * moveForce;
        }
    }

    void ActivatePowerUp()
    {
        isPowerUpActive = true;
        Time.timeScale = 0f;
        StartCoroutine(DeactivatePowerUp());
    }

    IEnumerator DeactivatePowerUp()
    {
        yield return new WaitForSecondsRealtime(powerUpDuration);
        Time.timeScale = 1f;
        isPowerUpActive = false;
        onlyOnce = true;
    }
}
