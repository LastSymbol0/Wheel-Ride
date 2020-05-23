using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    static public int Score = 0;
    static public bool IsGameStarted = false;
    Vector3 scoreCounterOffset = new Vector3(200, 100, 0);
    Vector3 scoreCounterPosition;

    public static void Restart()
    {
        Score = 0;
        IsGameStarted = false;
        SceneManager.LoadScene("MainScene");
    }

    void Start()
    {
        scoreCounterPosition = new Vector3(
                    Screen.width / 2f - scoreCounterOffset.x,
                    Screen.height / 2f - scoreCounterOffset.y,
                    0 - scoreCounterOffset.z);
    }

    void StartGame()
    {
        IsGameStarted = true;
        text.GetComponent<RectTransform>().localPosition = scoreCounterPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu_Scene_New", LoadSceneMode.Single);
        }

        if (!IsGameStarted)
        {
            return;
        }

        text.text = $"{8 - Score} cans left";

        if (Score == 8)
        {
            transform.Translate(transform.up * 1f);
            text.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            text.text = "Level completed!\nPress 'R' to restart\n'Esc' to main menu";
        }
        if (Score == -1)
        {
            text.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            text.text = "Level failed!\nPress 'R' to restart\n'Esc' to main menu";
        }

    }

    /******** UI Text Section ********/

    private enum UpDown { Down = -1, Start = 0, Up = 1 };
    private Text text;
    private UpDown textChanged = UpDown.Start;

    void Awake()
    {
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = "To complete level you need to collect 8 red bull's cans\nPress space to start!";
        text.fontSize = 48;
        text.alignment = TextAnchor.MiddleCenter;

        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
    }
}
