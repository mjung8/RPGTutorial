using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private BattleUnit enemyUnit;

    [SerializeField]
    private BattleHud enemyHud;

    [SerializeField]
    private BattleUnit playerUnit;

    [SerializeField]
    private BattleHud playerHud;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Pokemon);

        playerUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
    }
}
