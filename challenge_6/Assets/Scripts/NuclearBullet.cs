using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearOption : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign the bullet prefab in the inspector
    public AudioClip nuclearAudio; // Assign your audio clip in the inspector
    private AudioSource audioSource; // AudioSource component

    public float hoverHeight = 5.0f; // How high the bullet will hover above enemies
    public float hoverDuration = 1.0f; // How long the bullet will hover before crashing down

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource component if not already added
        audioSource.clip = nuclearAudio; // Assign the audio clip to the AudioSource
    }

    void Update()
    {
        // Check if the spacebar is pressed and if there are enemies
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            ActivateNuclearOption();
        }
    }

    public void ActivateNuclearOption()
    {
        
        if (nuclearAudio.length < 9f)
        {
            Debug.LogWarning("Audio clip is shorter than the end time.");
            return; // Exit if the audio clip is too short
        }

        // Start playback at the 5-second mark
        audioSource.time = 6f;
        audioSource.Play();

        // Start a coroutine to stop the audio after 4 seconds
        StartCoroutine(StopAudioAfterDelay(2.5f));

        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            Debug.Log("No enemies found.");
            return;
        }

        // Spawn a bullet for each enemy
        foreach (GameObject enemy in enemies)
        {
            GameObject bullet = Instantiate(bulletPrefab, enemy.transform.position + Vector3.up * hoverHeight, Quaternion.identity);
            bullet.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            StartCoroutine(HoverAndCrash(bullet, enemy));
        }
    }

    private IEnumerator StopAudioAfterDelay(float delay)
    {
        // Wait for the duration of the audio (4 seconds)
        yield return new WaitForSeconds(delay);

        // Stop the audio
        audioSource.Stop();
    }

    IEnumerator HoverAndCrash(GameObject bullet, GameObject enemy)
    {
        float elapsedTime = 0;
        while (elapsedTime < hoverDuration)
        {
            if (enemy == null) break;

            bullet.transform.position = enemy.transform.position + Vector3.up * hoverHeight;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while (bullet.transform.position.y > enemy.transform.position.y)
        {
            if (enemy == null) break;

            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, enemy.transform.position, 10f * Time.deltaTime);
            yield return null;
        }

        if (enemy != null) Destroy(enemy);
        Destroy(bullet);
    }
}
