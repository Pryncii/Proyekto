using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class COFFEEBUY : MonoBehaviour
{

    private string Coffee = "com.PrinceBuencamino.EscapetheMyth.Coffee";
    // Start is called before the first frame update

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == Coffee)
        {
            PlayerPrefs.SetInt("coff", 1);
            Debug.Log("Complete");
           
        }
    }
}
