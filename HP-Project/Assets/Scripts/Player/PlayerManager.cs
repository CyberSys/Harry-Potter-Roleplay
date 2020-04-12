using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private string playerName = "default_name";
    public enum PlayerHouse {Gryffindor, Ravenclaw, Hufflepuff, Slytherin};
    public PlayerHouse playerHouse;
    public int playerYear = 0;
}
