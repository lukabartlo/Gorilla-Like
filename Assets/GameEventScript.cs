using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEventScript : MonoBehaviour
{
    public Vector2 wind;
    public float Timer = 10f;
    public bool PlayerTurn = true;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI TurnPlayerText;

    private GameObject player;
    private GameObject WindSprite;

    // Start is called before the first frame update
    void Start()
    {
        wind = new Vector2(Random.Range(-3, 3), 0);
        player = GameObject.Find("Player");
        TimeText = GameObject.Find("CanvasText").transform.Find("TimerText").GetComponent<TextMeshProUGUI>();
        TurnPlayerText = GameObject.Find("CanvasText").transform.Find("TurnText").GetComponent<TextMeshProUGUI>();
        WindSprite = GameObject.Find("WindSprite");
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= 1f * Time.deltaTime;
        DisplayTime(Timer);
        DisplayTurn();
        if (Timer <= 0f && PlayerTurn == true)
        {
            wind = new Vector2(Random.Range(-3, 3), 0);
            PlayerTurn = false;
            Timer = 10f;
        }
        else if (Timer <= 0F && PlayerTurn == false)
        {
            wind = new Vector2(Random.Range(-3, 3), 0);
            PlayerTurn = true;
            Timer = 10f;
        }
        player.GetComponent<Player>().TimerOver = PlayerTurn;

        Sprite newsprite = null;
       
        switch ((int)wind.x)
        {
            case -3:
                newsprite = Resources.Load<Sprite>("LeftWindArrow 3");
                break;
            case -2:
                newsprite = Resources.Load<Sprite>("LeftWindArrow 2");
                break;
            case -1:
                newsprite = Resources.Load<Sprite>("LeftWindArrow 1");
                break;
            case 0:
                newsprite = Resources.Load<Sprite>("NoWind");
                break;
            case 1:
                newsprite = Resources.Load<Sprite>("RightWindArrow 1");
                break;
            case 2:
                newsprite = Resources.Load<Sprite>("RightWindArrow 2");
                break;
            case 3:
                newsprite = Resources.Load<Sprite>("RightWindArrow 3");
                break;
        }
        WindSprite.GetComponent<SpriteRenderer>().sprite = newsprite;
    }

    void DisplayTime(float TimeToDisplay)
    {
        TimeToDisplay += 1;
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);
        TimeText.text = string.Format("{0}", seconds);
    }

    void DisplayTurn()
    {
        if (PlayerTurn == true)
        {
            TurnPlayerText.text = "Player Turn";
        }

        else if (PlayerTurn == false) 
        {
            TurnPlayerText.text = "AI Turn";
        }
    }
}
