
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    Gradient gradient;

    [SerializeField]
    Image Fill;

    //**************patie_initialisation**********
   public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Fill.color = gradient.Evaluate(1f);
    }

    //****partie_afficher**************
    public void setHealth(int health)
    {
        slider.value = health;
        Fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
