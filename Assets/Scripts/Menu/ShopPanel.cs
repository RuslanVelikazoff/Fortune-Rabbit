using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private Button[] buyButton;
    [SerializeField] 
    private Button[] selectButton;
    [SerializeField]
    private GameObject[] selectedGameObject;
    [SerializeField]
    private GameObject[] priceGameObjects;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI cloverText;
    private int cloverAmount;
    private int[] price = new[] {0, 15, 30, 45};

    private void OnEnable()
    {
        SetCloverText();
        for (int i = 0; i < buyButton.Length; i++)
        {
            SetRabbitGameObjects(i);
        }
        
        ShopButtonClickAction();
    }

    private void ShopButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (buyButton[0] != null)
        {
            buyButton[0].onClick.AddListener(() =>
            {
                BuyRabbit(0);
            });
        }
        
        if (buyButton[1] != null)
        {
            buyButton[1].onClick.AddListener(() =>
            {
                BuyRabbit(1);
            });
        }
        
        if (buyButton[2] != null)
        {
            buyButton[2].onClick.AddListener(() =>
            {
                BuyRabbit(2);
            });
        }
        
        if (buyButton[3] != null)
        {
            buyButton[3].onClick.AddListener(() =>
            {
                BuyRabbit(3);
            });
        }

        if (selectButton[0] != null)
        {
            selectButton[0].onClick.AddListener(() =>
            {
                SelectRabbit(0);
            });
        }

        if (selectButton[1] != null)
        {
            selectButton[1].onClick.AddListener(() =>
            {
                SelectRabbit(1);
            });
        }

        if (selectButton[2] != null)
        {
            selectButton[2].onClick.AddListener(() =>
            {
                SelectRabbit(2);
            });
        }

        if (selectButton[3] != null)
        {
            selectButton[3].onClick.AddListener(() =>
            {
                SelectRabbit(3);
            });
        }
    }

    private void BuyRabbit(int index)
    {
        if (cloverAmount >= price[index])
        {
            CurencyData.Instance.MinusClover(price[index]);
            SetCloverText();
            StoreData.Instance.BuyRabbit(index);

            for (int i = 0; i < buyButton.Length; i++)
            {
                SetRabbitGameObjects(i);
            }
        }
    }

    private void SelectRabbit(int index)
    {
        if (StoreData.Instance.GetPurchasedRabbit(index))
        {
            StoreData.Instance.SelectRabbit(index);

            for (int i = 0; i < buyButton.Length; i++)
            {
                SetRabbitGameObjects(i);
            }
        }
    }

    private void SetCloverText()
    {
        cloverAmount = CurencyData.Instance.GetCloverAmount();
        cloverText.text = cloverAmount.ToString();
    }

    private void SetRabbitGameObjects(int index)
    {
        if (StoreData.Instance.GetPurchasedRabbit(index))
        {
            if (StoreData.Instance.GetSelectedRabbit(index))
            {
                buyButton[index].gameObject.SetActive(false);
                priceGameObjects[index].SetActive(false);
                selectButton[index].gameObject.SetActive(false);
                selectedGameObject[index].SetActive(true);
            }
            else
            {
                buyButton[index].gameObject.SetActive(false);
                priceGameObjects[index].SetActive(false);
                selectButton[index].gameObject.SetActive(true);
                selectedGameObject[index].SetActive(false);
            }
        }
        else
        {
            buyButton[index].gameObject.SetActive(true);
            priceGameObjects[index].SetActive(true);
            selectButton[index].gameObject.SetActive(false);
            selectedGameObject[index].SetActive(false);
        }
    }
}
