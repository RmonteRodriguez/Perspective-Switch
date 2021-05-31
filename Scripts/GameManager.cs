using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 1.5f;

    public bool is2D;
    public bool isSwitchedOne;
    public bool isSwitchedTwo;

    public GameObject thiccPlayer;
    public GameObject flatPlayer;
    public GameObject[] flatPlatforms;
    public GameObject[] switchPlatformsOne;
    public GameObject[] switchPlatformsTwo;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        isSwitchedOne = false;
        isSwitchedTwo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PerspectiveSwitch();
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
            SwitchPlatform();
        }
    }

    public void PerspectiveSwitch()
    {
        if (is2D)
        {
            thiccPlayer.transform.position = flatPlayer.transform.position;
            thiccPlayer.SetActive(true);
            flatPlayer.SetActive(false);

            for (int i = 0; i < flatPlatforms.Length; i++)
            {
                flatPlatforms[i].SetActive(false);
            }

            is2D = false;
        }
        else if (is2D == false)
        {
            flatPlayer.transform.position = thiccPlayer.transform.position;
            thiccPlayer.SetActive(false);
            flatPlayer.SetActive(true);

            for (int i = 0; i < flatPlatforms.Length; i++)
            {
                flatPlatforms[i].SetActive(true);
            }

            is2D = true;
        }
    }

    public void SwitchPlatform()
    {
        if (isSwitchedOne)
        {
            for (int i = 0; i < switchPlatformsOne.Length; i++)
            {
                switchPlatformsOne[i].SetActive(true);
            }
            isSwitchedOne = false;
        }
        else if (isSwitchedOne == false)
        {
            for (int i = 0; i < switchPlatformsOne.Length; i++)
            {
                switchPlatformsOne[i].SetActive(false);
            }
            isSwitchedOne = true;
        }

        if (isSwitchedTwo)
        {
            for (int i = 0; i < switchPlatformsTwo.Length; i++)
            {
                switchPlatformsTwo[i].SetActive(true);
            }
            isSwitchedTwo = false;
        }
        else if (isSwitchedTwo == false)
        {
            for (int i = 0; i < switchPlatformsTwo.Length; i++)
            {
                switchPlatformsTwo[i].SetActive(false);
            }
            isSwitchedTwo = true;
        }

        timer = 1.5f;
    }
}
