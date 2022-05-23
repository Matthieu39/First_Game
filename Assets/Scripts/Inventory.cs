using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
  public int coinsCount;
  public Text coinsCountText;

  public List<Item> content = new List<Item>();
  public int ContentCurrentIndex = 0;
  // public Pocket pocket;
  public int test;
  public Poison poison;
  public int pocketNb;
  public Item NoItem;


public static Inventory instance;

private void Awake(){

  if(instance != null){
    Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scene");
    return ;
    // PERMET DE S SASSURER QU IL N Y A QU UN SEUL INVENTAIRE
    //Singleton
  }
  instance = this;



}

void Update(){
  if(coinsCount<0)
  {
    coinsCount=0;
    UpdateText();

  }
  poison = GameObject.FindGameObjectWithTag("Poison").GetComponent<Poison>();

}


  public void ConsumeItem()
    {


      Item currentItem = content[pocketNb];
      content[pocketNb] = null;
       PlayerHealth.instance.Heal(currentItem.hp);
       poison.isPoisoned = currentItem.stillpoisoned;
       InventoryUI();
    }


    public void ReturnPocket0()
    {
       pocketNb = 0;
    }

    public void ReturnPocket1()
    {
      pocketNb = 1;
    }

    public void ReturnPocket2()
    {
      pocketNb = 2;
    }
    public void ReturnPocket3()
    {
      pocketNb = 3;
    }
    public void ReturnPocket4()
    {
      pocketNb = 4;
    }
    public void ReturnPocket5()
    {
      pocketNb = 5;
    }
    public void ReturnPocket6()
    {
      pocketNb = 6;
    }
    public void ReturnPocket7()
    {
      pocketNb = 7;
    }


    public void InventoryUI()
      {

        for (int i = 0; i<=7; i++)
          {
          GameObject go = GameObject.FindGameObjectWithTag("Pocket"+i);
          // Image itemImage;

            if(content[i] != null)
              {
                // itemImage.sprite = content[i].image;
                // go.GetComponent<SpriteRenderer>().sprite = itemImage.sprite;

                go.GetComponent<Image>().sprite = content[i].image;
              }else{
                go.GetComponent<Image>().sprite = null;
              }
          }
      }


  public void AddCoins(int count)
  {
    coinsCount += count;
    UpdateText();
  }
  public void RemoveCoins(int count)
  {
    coinsCount -= count;
    UpdateText();
  }

  public void UpdateText()
  {
    coinsCountText.text = coinsCount.ToString();

  }

}
