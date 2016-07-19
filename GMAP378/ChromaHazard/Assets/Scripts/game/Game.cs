using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {

    private static Game instance;

    public static Game Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    public List<Player> Players
    {
        get;
        private set;
    }

    public GameMode Mode
    {
        get;
        private set;
    }

    public Game()
    {
        Mode = GameMode.LastManStanding;
        Players = new List<Player>();
    }

    public void AddPlayer (int id, string name, Color characterColor, InputScheme scheme)
    {
        Players.Add(new Player(id, name, characterColor, scheme));
    }

    public enum GameMode
    {
        LastManStanding
    }

    public string Winner
    {
        get;
        private set;
    }

    public void GameOver (string winner)
    {
        Application.LoadLevel("GameOver_V1");
        Winner = winner;
    }
}
