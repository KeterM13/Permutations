using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI shipCodeText;
    public TMP_InputField searchCodeField;
    public Button searchCodeButton;
    public Button nextButton;
    public Button previousButton;
    public Button showCodesButton;

    /*public int capIndex;
    public int metalIndex;
    public int metalHoldIndex;
    public  int neonIndex;*/

    public int permutationCode;

    bool isOver=false;

    public ColourShip ship;

    public List<Material> capsuleColors;
    public List<Material> metalColors;
    public List<Material> neonColors;

    // Start is called before the first frame update
    void Start()
    {
        searchCodeButton.onClick.AddListener(SearchCode);
        nextButton.onClick.AddListener(NextCombination);
        previousButton.onClick.AddListener(PreviousCombination);
        showCodesButton.onClick.AddListener(ShowCodes);
    }

    // Update is called once per frame
    void Update()
    {
        //colorIndex++;
    }

   public void SearchCode()
    {
        Debug.Log(permutationCode);
        permutationCode = int.Parse(searchCodeField.text);
        int lightsIndex = permutationCode % neonColors.Count;
        int holderIndex = Mathf.FloorToInt(permutationCode / neonColors.Count) % metalColors.Count;
        int shipIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count)) % metalColors.Count;
        int capsuleIndex = Mathf.FloorToInt(permutationCode / (neonColors.Count * metalColors.Count * metalColors.Count)) % capsuleColors.Count;

        ship.capsuleMaterial = capsuleColors[capsuleIndex];
        ship.shipMaterial = metalColors[shipIndex];
        ship.holderMaterial = metalColors[holderIndex];
        ship.lightsMaterial = neonColors[lightsIndex];
        ship.ColourShipNow();
        
        //shipCodeText.text = $"Code {permutationCode.ToString()}";

        /*ship.capsuleMaterial = capsuleColors[colorIndex % capsuleColors.Count];

        metalIndex = (colorIndex / capsuleColors.Count) % metalColors.Count;
        ship.shipMaterial = metalColors[metalIndex];

        metalHoldIndex = (metalIndex / metalColors.Count) % metalColors.Count;
        ship.holderMaterial = metalColors[metalHoldIndex];

        neonIndex = (metalHoldIndex / metalColors.Count) % neonColors.Count;
        ship.lightsMaterial = neonColors[neonIndex];

        shipCodeText.text = $"Code {colorIndex}";
        ship.ColourShipNow();*/

    }

   public void NextCombination()
    {
        permutationCode++;
        SearchCode();
    }

   public void PreviousCombination()
    {
        permutationCode--;
        SearchCode();
    }

   public void ShowCodes()
    {
        
        
        ship.ColourShipNow();
        
    }

   public void GetCode()
    {
        int.TryParse(searchCodeField.text, out permutationCode);
        Debug.Log(permutationCode);
    }

    
    /*IEnumerator ChangeColors()
    {
        
        
        
        while (isOver == false)
        {
            yield return new WaitForSeconds(0.01f);
            ship.lightsMaterial = neonColors[neonIndex];
            ship.ColourShipNow();
            neonIndex++;
            if (neonIndex >= neonColors.Count)
            {
                neonIndex = 0;
                
                ship.capsuleMaterial = capsuleColors[capIndex];
                capIndex++;
                if (capIndex>=capsuleColors.Count)
                {
                    capIndex = 0;
                    
                    ship.shipMaterial = metalColors[metalIndex];
                    metalIndex++;

                    if (metalIndex>=metalColors.Count)
                    {
                        metalIndex = 0;
                       
                        ship.holderMaterial = metalColors[metalHoldIndex];
                        metalHoldIndex++;
                        if ( metalHoldIndex>= metalColors.Count)
                        {
                            isOver = true;
                        }
                    }
                    
                }
            }

        }
    }*/
}
