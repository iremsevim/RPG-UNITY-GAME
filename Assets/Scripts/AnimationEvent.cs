using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public List<AnimProfil> allanims;

    public void PlayAnimOnAwake(AnimType type)
    {
        AnimProfil findedanim =allanims.Find(x => x.animID == type);
        findedanim?.OnAnim?.Invoke();
    }


    [System.Serializable]
    public class AnimProfil
    {
        public AnimType animID;
        public UnityEvent OnAnim;
        public AnimProfil(AnimType _ID,params UnityAction[] _OnAnim)
        {
            animID = _ID;
            OnAnim = new UnityEvent();
            foreach (var item in _OnAnim)
            {
                OnAnim.AddListener(item);
            }
            
        }

    }
}

public enum AnimType
{
   swordattack=0,AIAttack=1,death=2,strikeend=3
}
