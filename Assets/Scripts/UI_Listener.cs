using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Listener : MonoBehaviour
{
    public bool IsOpened = false;
    public void OpenedClosedInventory(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Worker.UI_ShowEnvanter();
                break;
            case 1:
                Worker.UIHideInventory();
                break;
        }
    }
}
