using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownGameMode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public IEnumerator StartGameMode()
    {
        yield return new WaitForSeconds(1);
        text.text = "3";
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        text.text = "START";
        GameController.Instance.SetGameMode(GameModeId.Gameplay);
        yield return new WaitForSeconds(1);
        text.text = "";
    }
}
