using UnityEngine;
using System.Collections;

public class Player {

    public Player(int id, string name, Color characterColor, InputScheme scheme)
    {
        Id = id;
        Name = name;
        CharacterColor = characterColor;
        ControllerScheme = scheme;
        Dead = false;
    }

    public int Id
    {
        get;
        private set;
    }
    
    public string Name
    {
        get;
        private set;
    }

    public Color CharacterColor
    {
        get;
        private set;
    }

    public InputScheme ControllerScheme
    {
        get;
        private set;
    }

    public enum CharacterName
    {
        SampleCharacter
    }

    public bool Dead
    {
        get;
        private set;
    }

    public void Death()
    {
        Dead = true;
    }
}
