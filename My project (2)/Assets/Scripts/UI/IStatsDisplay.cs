using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatsDisplay
{
    void UpdateTime(float time);
    void UpdateKills(int kills);
    void UpdateLevel(int level);
}
