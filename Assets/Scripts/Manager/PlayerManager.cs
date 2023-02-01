using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonTemplate<PlayerManager>
{
    List<Player> players = new List<Player>();


    public Player GetPlayer => players.Count > 0 ? players[0] : null;

    public void Register(Player _player)
    {
        players.Add(_player);
    }
}
