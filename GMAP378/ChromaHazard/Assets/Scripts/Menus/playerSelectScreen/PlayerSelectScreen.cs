using UnityEngine;
using System.Collections;

public class PlayerSelectScreen : MonoBehaviour {

    public PlayerSelect[] players;
    public string levelToLoad;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playersReady())
        {
            for (int i=0; i < players.Length; i++)
            {
                PlayerSelect p = players[i];
                if (p.Joined)
                {
                    p.Scheme.color = p.CharacterColor;
                    Game.Instance.AddPlayer(i, p.Name, p.CharacterColor, p.Scheme);
                }
            }
            
            // TODO: 
            // Wait a second
            Application.LoadLevel(levelToLoad);
        }
	}

    private bool playersReady()
    {
        // we need at least one player
        if (!players[0].Joined)
            return false;

        // then if all joined players are ready
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].Joined)
            {
                if (!players[i].Ready)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void ReturnToMenu()
    {
        gameObject.SetActive(false);
    }
}
