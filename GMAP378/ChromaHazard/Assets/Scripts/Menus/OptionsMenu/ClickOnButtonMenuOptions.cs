using UnityEngine;
using System.Collections;

public class ClickOnButtonMenuOptions : MonoBehaviour
{

        public ChangeGameMode button;
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClickRightButton(int i)
        {
        i++;

        if (Application.loadedLevelName == "Options_V1")//First Menu
        {
            if (i == 1)
            {
                //vol music
            }
            if (i == 2)
            {
                //vol sound
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeModeIncrease();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().increaseLife();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().increaseTimer();
            }
            if (i == 6)
            {
                button.GetComponent<ChangeGameMode>().ChangePunch();
            }
            if (i == 7)
            {
                button.GetComponent<ChangeGameMode>().ChangeBomb();
            }
            if (i == 8)
            {
                //menu
            }
            if (i == 9)
            {
                //menu
            }
            if (i == 10)
            {
                //menu
            }
        }
        else if (Application.loadedLevelName == "Options_V2")//Second Menu
        {
            if (i == 1)
            {
                button.GetComponent<ChangeGameMode>().ChangePushableBombs();
            }
            if (i == 2)
            {
                button.GetComponent<ChangeGameMode>().ChangePickableBombs();
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeInk();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().ChangeRandomInk();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().ChangeLaserIncrease();
            }
        }
        else if (Application.loadedLevelName == "Options_V3")//items Menu
        {
            if (i == 1)
            {
                button.GetComponent<ChangeGameMode>().ChangeBounce();
            }
            if (i == 2)
            {
                button.GetComponent<ChangeGameMode>().ChangeIce();
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeEraser();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().ChangeGravity();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().ChangeFast();
            }
            if (i == 6)
            {
                button.GetComponent<ChangeGameMode>().ChangeGoo();
            }
            if (i == 7)
            {
                button.GetComponent<ChangeGameMode>().ChangeInvisibility();
            }
            if (i == 8)
            {
                button.GetComponent<ChangeGameMode>().ChangeLivesItem();
            }
        }


    }

        public void ClickLeftButton(int i)
        {
        i++;

        if (Application.loadedLevelName == "Options_V1")//First Menu
        {
            if (i == 1)
            {
                //vol music
            }
            if (i == 2)
            {
                //vol sound
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeModeDecrease();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().reduceLife();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().reduceTimer();
            }
            if (i == 6)
            {
                button.GetComponent<ChangeGameMode>().ChangePunch();
            }
            if (i == 7)
            {
                button.GetComponent<ChangeGameMode>().ChangeBomb();
            }
            if (i == 8)
            {
                //menu
            }
            if (i == 9)
            {
                //menu
            }
            if (i == 10)
            {
                //menu
            }
        }
        else if (Application.loadedLevelName == "Options_V2")//Second Menu
        {
            if (i == 1)
            {
                button.GetComponent<ChangeGameMode>().ChangePushableBombs();
            }
            if (i == 2)
            {
                button.GetComponent<ChangeGameMode>().ChangePickableBombs();
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeInk();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().ChangeRandomInk();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().ChangeLaserDecrease();
            }
        }
        else if (Application.loadedLevelName == "Options_V3")//items Menu
        {
            if (i == 1)
            {
                button.GetComponent<ChangeGameMode>().ChangeBounce();
            }
            if (i == 2)
            {
                button.GetComponent<ChangeGameMode>().ChangeIce();
            }
            if (i == 3)
            {
                button.GetComponent<ChangeGameMode>().ChangeEraser();
            }
            if (i == 4)
            {
                button.GetComponent<ChangeGameMode>().ChangeGravity();
            }
            if (i == 5)
            {
                button.GetComponent<ChangeGameMode>().ChangeFast();
            }
            if (i == 6)
            {
                button.GetComponent<ChangeGameMode>().ChangeGoo();
            }
            if (i == 7)
            {
                button.GetComponent<ChangeGameMode>().ChangeInvisibility();
            }
            if (i == 8)
            {
                button.GetComponent<ChangeGameMode>().ChangeLivesItem();
            }
        }
    }
}
