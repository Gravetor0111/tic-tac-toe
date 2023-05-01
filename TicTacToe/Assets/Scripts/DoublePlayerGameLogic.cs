using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoublePlayerGameLogic : MonoBehaviour
{   
    public struct Player
    {   
        public string name;
        public string sign;
        public bool turn;
        public int wins;
    }

    public static Player p1, p2;
    public TextMeshProUGUI currentTurnPlayer, player1Txt;

    // Start is called before the first frame update
    void Start()
    {
        GetNames();
        player1Txt.text = p1.name + " Picks: ";
        p1.turn = false;
        p2.turn = false;
    }
    
    void GetNames()
    {
        p1.name = StartDoublePlayerGame.p1;
        p2.name = StartDoublePlayerGame.p2;
        Debug.Log(p1.name + p1.sign);
        Debug.Log(p2.name + p2.sign);
    }

    public void ShiftTurn()
    {
        if (!p1.turn && !p2.turn)
        {
            p1.turn = true;
            currentTurnPlayer.text = p1.name + "'s Turn: ";
        }
        else
        {
            if (p1.turn && !p2.turn)
            {
                
            }
        }
        
    }
    
}
