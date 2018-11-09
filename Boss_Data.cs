using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Data {
    private int HP;

    public Boss_Data(int _HP)
    {
        HP = _HP;
    }

    public void decreaseHP(int damage)
    {
        HP -= damage;
    }

    public int getHP()
    {
        return HP;
    }
}
