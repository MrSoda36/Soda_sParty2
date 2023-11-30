using UnityEngine;
using DG.Tweening;

public class ShakeByInputSystem : MonoBehaviour
{

    int CocaCounter = 0;
    int PepsiCounter = 0;
    int FantaCounter = 0;
    int SpriteCounter = 0;

    public void OnMashingFirstPlayer()
    {
        Shake(CocaCounter);
        Debug.Log("First Player");
    }
    public void OnMashingSecondPlayer()
    {
        Shake(PepsiCounter);
        Debug.Log("Second Player");
    }
    public void OnMashingThirdPlayer() 
    {
        Shake(FantaCounter);
        Debug.Log("Third Player"); 
    }
    public void OnMashingFourthPlayer() 
    {
        Shake(SpriteCounter);
        Debug.Log("Fourth Player"); 
    }

    void Shake(int n)
    {
        n++;
        Debug.Log(n) ;
    }
}
