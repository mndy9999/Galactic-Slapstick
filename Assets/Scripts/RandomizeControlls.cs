using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomizeControlls : MonoBehaviour
{

    public delegate void ControlsChanged(List<CustomKey> keys);
    public static event ControlsChanged OnControlsChanged;

    List<CustomKey> codes;

    private PlayerMovementController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerMovementController>();

        var a = new CustomKey { Code = KeyCode.A, Status = KeyStatus.Left };
        var w = new CustomKey { Code = KeyCode.W, Status = KeyStatus.Up };
        var d = new CustomKey { Code = KeyCode.D, Status = KeyStatus.Right };
        var s = new CustomKey { Code = KeyCode.S, Status = KeyStatus.Disabled };

        codes = new List<CustomKey>() { a, w, d, s };

        if (OnControlsChanged != null)
            OnControlsChanged.Invoke(codes);
    }


    public void Randomize()
    {
        var rand = Random.Range(1, 4);

        for (int i = 0; i < codes.Count; i++)
        {
            var temp = codes[i];
            int stat = ((int)temp.Status + rand);
            int div = stat % 4;
            temp.Status = (KeyStatus)div;
            codes[i] = temp;
        }

        var left = codes.Where(s => s.Status == KeyStatus.Left).FirstOrDefault().Code;
        var up = codes.Where(s => s.Status == KeyStatus.Up).FirstOrDefault().Code;
        var right = codes.Where(s => s.Status == KeyStatus.Right).FirstOrDefault().Code;
        var disabled = codes.Where(s => s.Status == KeyStatus.Disabled).FirstOrDefault().Code;

        playerController.UpdateControlls(left, right, up);

        if (OnControlsChanged != null)
            OnControlsChanged.Invoke(codes);
    }
}

public struct CustomKey
{
    public KeyStatus Status;
    public KeyCode Code;
}

public enum KeyStatus { Left = 0, Up = 1, Right = 2, Disabled = 3 };

static class KeyStatusExtensions
{
    public static Color GetColor(this KeyStatus key)
    {
        switch (key)
        {
            case KeyStatus.Left: return new Color32(255, 93, 230, 255);
            case KeyStatus.Up: return new Color32(0, 200, 255, 255);
            case KeyStatus.Right: return new Color32(255, 150, 54, 255);
            case KeyStatus.Disabled: return new Color32(164, 164, 164, 255);
            default: return Color.white;
        }
    }
}
