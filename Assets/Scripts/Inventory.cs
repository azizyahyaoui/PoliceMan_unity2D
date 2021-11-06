
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{
    [SerializeField]
     int coinsCount;
    [SerializeField]
     Text coinsCountText;

    public static Inventory instance;



    private void Awake()
    {
        if (instance !=null)
        {
            Debug.LogWarning("there is more than one instance of inventory on the scene ");
            return;
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }
}
