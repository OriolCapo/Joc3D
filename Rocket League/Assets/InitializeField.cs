using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeField : MonoBehaviour {

    private int playerMode;
    private int playerCar;
    private CameraController cameraController;

    public GameObject cameraJoc;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject ally1_1;
    public GameObject ally1_2;
    public GameObject ally1_3;
    public GameObject ally2_1;
    public GameObject ally2_2;
    public GameObject ally2_3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    public AudioSource music4;
    public AudioSource music5;


    // Use this for initialization
    void Start () {
        playerMode = PlayerPrefs.GetInt("Mode");
        playerCar = PlayerPrefs.GetInt("SelectedCar");

        int musicTrack = Random.Range(1, 7);

        switch (musicTrack)
        {
            case 1:
                music1.Play();
                break;
            case 2:
                music2.Play();
                break;
            case 3:
                music3.Play();
                break;
            case 4:
                music4.Play();
                break;
            case 5:
                music5.Play();
                break;
            case 6:
                music1.Play();
                music1.Play();
                break;
            default:
                music1.Play();
                break;
        }

        if (playerMode == 1)
        {
            enemy1.SetActive(true);
            activatePlayer(playerCar);

        }else if(playerMode == 2)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            activatePlayer(playerCar);
            activateAlly1(playerCar);

        }else if (playerMode == 3)
        {
            enemy1.SetActive(true);
            enemy2.SetActive(true);
            enemy3.SetActive(true);
            activatePlayer(playerCar);
            activateAlly1(playerCar);
            activateAlly2(playerCar);

        }
        else { }



    }

    private void activatePlayer(int playercar)
    {
        cameraController = cameraJoc.GetComponent<CameraController>();
        if (playercar == 1)
        {
            player1.SetActive(true);
        } else if (playercar == 2)
        {
            player2.SetActive(true);
        } else if (playercar == 3)
        {
            player3.SetActive(true);
        }
        cameraController.changeSelectedCar(playercar);
    }

    private void activateAlly1(int playercar)
    {
        if (playercar == 1)
        {
            ally1_2.SetActive(true);
        }
        else if (playercar == 2)
        {
            ally1_3.SetActive(true);
        }
        else if (playercar == 3)
        {
            ally1_1.SetActive(true);
        }

    }

    private void activateAlly2(int playercar)
    {
        if (playercar == 1)
        {
            ally2_3.SetActive(true);
        }
        else if (playercar == 2)
        {
            ally2_1.SetActive(true);
        }
        else if (playercar == 3)
        {
            ally2_2.SetActive(true);
        }

    }

}


