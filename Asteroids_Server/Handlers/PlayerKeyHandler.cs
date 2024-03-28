using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Server.Handlers;

public class PlayerKeyHandler
{
    public PlayerKeyHandler() { }

    public void KeyDownHandle(Player_Server player,Keys key)
    {
        player.KeyDown(key);
    }
    public void KeyUpHandle(Player_Server player, Keys key) 
    {
        player.KeyUp(key);
    }
}
