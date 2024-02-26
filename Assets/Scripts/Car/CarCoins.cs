using TMPro;
using UnityEngine;

public class CarCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counter;

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            counter.text = "SCORE:\n" + value;
            _score = value;
        }
    }
}
