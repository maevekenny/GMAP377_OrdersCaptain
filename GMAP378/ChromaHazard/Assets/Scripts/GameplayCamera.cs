using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameplayCamera : MonoBehaviour {

    private Camera camera;
    private float shake;
    private Vector3 originalPosition;
    private Vector3 currentPosition;
    private List<Transform> players;

    public Bounds levelBounds;
    public float shakeAmount;
    public float decreaseFactor;

    public float cameraMovementEase;
    public float cameraZoomEase;
    public float maxZoomLevel;
    public float minZoomLevel;
    public float xOffset;

	// Use this for initialization
	void Start () {
        camera = gameObject.GetComponent<Camera>();
        originalPosition = camera.transform.position;
        players = new List<Transform>();
        shake = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        ZoomToPlayers();
        currentPosition = transform.position;
        ShakeScreen();
	}

    /// <summary>
    /// Zoom camera to players. If players are close together, 
    /// the camera will zoom into that area. If they are far apart, 
    /// the camera will zoom out to encompass everyone.
    /// </summary>
    private void ZoomToPlayers()
    {
        // get the extent of the bounds of all the players
        Bounds playerBounds = new Bounds();
        for (int i = 0; i < players.Count; i++)
        {
            if (i == 0)
            {
                playerBounds = new Bounds(players[i].position, players[i].position);
            }
            else
            {
                playerBounds.Encapsulate(players[i].position);
            }
        }

        // calculate target zoom level
        // linearly innterpolate betwen max and min zoom level 
        // depending on what percentage of the screen the players are taking up
        float percentage = Mathf.Max(
            playerBounds.size.x / levelBounds.size.x, // horizontal percentage
            playerBounds.size.y / levelBounds.size.y  // vertical percentage
        );
        float targetZoomLevel = Mathf.Lerp(maxZoomLevel, minZoomLevel, percentage);

        // lerp camera zoom level towards target zoom level
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoomLevel, cameraZoomEase) + 0.5f;
        
        // get the center location of all the players
        Vector3 targetPosition = playerBounds.center;

        // offeset x, so players can see a little higher
        targetPosition.x += xOffset;

        // TODO: don't let camera stray to far from origin if we are zoomed out

        // lock z
        targetPosition.z = originalPosition.z;

        // lerp camera position towards target position
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, cameraMovementEase);
    }

    /// <summary>
    /// Shakes the camera if the shake time is 
    /// greater than 0. Decays shakes over time.
    /// </summary>
    private void ShakeScreen()
    {
        if (shake > 0)
        {
            // restore original position to keep it from straying too far
            Vector3 newPos = currentPosition + Random.insideUnitSphere * shakeAmount * shake;
            // lock z
            newPos.z = originalPosition.z;
            camera.transform.localPosition = newPos;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
            camera.transform.position = currentPosition;
        }
    }

    /// <summary>
    /// Shake camera for a certain amount of seconds.
    /// </summary>
    /// <param name="time">The amount of time to shake for.</param>
    public void ShakeForSeconds(float time) 
    {
        shake = time;
    }

    /// <summary>
    /// Add a player to the list of transforms being tracked.
    /// </summary>
    /// <param name="t">The player's transform.</param>
    public void AddPlayerTransform(Transform t)
    {
        players.Add(t);
    }
}
