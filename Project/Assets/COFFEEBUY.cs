using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class COFFEEBUY : MonoBehaviour
{
    public GameObject done;
    private string Coffee = "com.PrinceBuencamino.EscapetheMyth.Coffee";
    // Start is called before the first frame update

    void Start()
    {
        gameObject.SetActive(PlayerPrefs.GetInt("coff", 0) == 0);
    }

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == Coffee)
        {
            PlayerPrefs.SetInt("coff", 1);
            Debug.Log("Complete");
            done.SetActive(true);
        }
    }
}
