using UnityEngine;
using UnityEngine.UI;

public class UITabManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject centerUIPanel;
    public GameObject leftUIPanel;
    public GameObject rightUIPanel;
    public GameObject runeUIPanel;

    [Header("Footer Buttons")]
    public Button btnStash;
    public Button btnStatus;
    public Button btnRune;
    public Button btnCube;
    public Button btnMap;

    private enum LeftMenuState { None, Stash, Status }
    private enum RightMenuState { None, Cube, Map }
    
    private LeftMenuState currentLeftState = LeftMenuState.None;
    private RightMenuState currentRightState = RightMenuState.None;
    
    private bool isCenterUIOpen = false;

    private void Start()
    {
        if (btnStash) btnStash.onClick.AddListener(OnClickStash);
        if (btnStatus) btnStatus.onClick.AddListener(OnClickStatus);
        if (btnRune) btnRune.onClick.AddListener(OnClickRune);
        if (btnCube) btnCube.onClick.AddListener(OnClickCube);
        if (btnMap) btnMap.onClick.AddListener(OnClickMap);

        CloseAllUIs();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleCenterUI();
        }
    }

    private void ToggleCenterUI()
    {
        isCenterUIOpen = !isCenterUIOpen;
        
        if (isCenterUIOpen)
        {
            centerUIPanel.SetActive(true);
            leftUIPanel.SetActive(false);
            rightUIPanel.SetActive(false);
            runeUIPanel.SetActive(false);
            
            currentLeftState = LeftMenuState.None;
            currentRightState = RightMenuState.None;
        }
        else
        {
            CloseAllUIs();
        }
    }

    private void CloseAllUIs()
    {
        isCenterUIOpen = false;
        if (centerUIPanel) centerUIPanel.SetActive(false);
        if (leftUIPanel) leftUIPanel.SetActive(false);
        if (rightUIPanel) rightUIPanel.SetActive(false);
        if (runeUIPanel) runeUIPanel.SetActive(false);

        currentLeftState = LeftMenuState.None;
        currentRightState = RightMenuState.None;
    }

    private void OnClickStash()
    {
        if (currentLeftState == LeftMenuState.Stash)
        {
            leftUIPanel.SetActive(false);
            currentLeftState = LeftMenuState.None;
            Debug.Log("Closed Stash");
        }
        else
        {
            leftUIPanel.SetActive(true);
            runeUIPanel.SetActive(false);
            currentLeftState = LeftMenuState.Stash;
            Debug.Log("Opened Left Panel: STASH");
        }
    }

    private void OnClickStatus()
    {
        if (currentLeftState == LeftMenuState.Status)
        {
            leftUIPanel.SetActive(false);
            currentLeftState = LeftMenuState.None;
            Debug.Log("Closed Status");
        }
        else
        {
            leftUIPanel.SetActive(true);
            runeUIPanel.SetActive(false);
            currentLeftState = LeftMenuState.Status;
            Debug.Log("Opened Left Panel: STATUS");
        }
    }

    private void OnClickCube()
    {
        if (currentRightState == RightMenuState.Cube)
        {
            rightUIPanel.SetActive(false);
            currentRightState = RightMenuState.None;
            Debug.Log("Closed Cube");
        }
        else
        {
            rightUIPanel.SetActive(true);
            runeUIPanel.SetActive(false);
            currentRightState = RightMenuState.Cube;
            Debug.Log("Opened Right Panel: CUBE");
        }
    }

    private void OnClickMap()
    {
        if (currentRightState == RightMenuState.Map)
        {
            rightUIPanel.SetActive(false);
            currentRightState = RightMenuState.None;
            Debug.Log("Closed Map");
        }
        else
        {
            rightUIPanel.SetActive(true);
            runeUIPanel.SetActive(false);
            currentRightState = RightMenuState.Map;
            Debug.Log("Opened Right Panel: MAP");
        }
    }

    private void OnClickRune()
    {
        if (runeUIPanel.activeSelf)
        {
            runeUIPanel.SetActive(false);
            Debug.Log("Closed Rune");
        }
        else
        {
            runeUIPanel.SetActive(true);
            leftUIPanel.SetActive(false);
            rightUIPanel.SetActive(false);
            
            currentLeftState = LeftMenuState.None;
            currentRightState = RightMenuState.None;
            
            Debug.Log("Opened Rune Panel");
        }
    }
}
