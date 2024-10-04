using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private Button[] buyButton;
    [SerializeField]
    private GameObject[] selectedGameObject;
    [SerializeField]
    private GameObject[] priceGameObject;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI cloverText;
    private int cloverAmout;
    private int[] price = new[] {30, 40};

    private void OnEnable()
    {
        SetCloverText();
        SetMegaJumpGameObjects();
        SetProtectiveGameObjects();
        UpgradeButtonClickAction();
    }

    private void UpgradeButtonClickAction()
    {
        if (buyButton[0] != null)
        {
            buyButton[0].onClick.AddListener(() =>
            {
                BuyMegaJump();
            });
        }

        if (buyButton[1] != null)
        {
            buyButton[1].onClick.AddListener(() =>
            {
                BuyProtective();
            });
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }

    private void SetCloverText()
    {
        cloverAmout = CurencyData.Instance.GetCloverAmount();
        cloverText.text = cloverAmout.ToString();
    }

    private void BuyMegaJump()
    {
        if (cloverAmout >= price[0])
        {
            CurencyData.Instance.MinusClover(price[0]);
            SetCloverText();
            StoreData.Instance.BuyMegaJump();
            SetMegaJumpGameObjects();
        }
    }

    private void SetMegaJumpGameObjects()
    {
        if (StoreData.Instance.GetPurchasedMegaJump())
        {
            buyButton[0].gameObject.SetActive(false);
            priceGameObject[0].SetActive(false);
            selectedGameObject[0].SetActive(true);
        }
        else
        {
            buyButton[0].gameObject.SetActive(true);
            priceGameObject[0].SetActive(true);
            selectedGameObject[0].SetActive(false);
        }
    }

    private void BuyProtective()
    {
        if (cloverAmout >= price[1])
        {
            CurencyData.Instance.MinusClover(price[1]);
            SetCloverText();
            StoreData.Instance.BuyProtective();
            SetProtectiveGameObjects();
        }
    }

    private void SetProtectiveGameObjects()
    {
        if (StoreData.Instance.GetPurchasedProtective())
        {
            buyButton[1].gameObject.SetActive(false);
            priceGameObject[1].SetActive(false);
            selectedGameObject[1].SetActive(true);
        }
        else
        {
            buyButton[1].gameObject.SetActive(true);
            priceGameObject[1].SetActive(true);
            selectedGameObject[1].SetActive(false);
        }
    }
}
