using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVisualChange : MonoBehaviour {
	public Slider healthSlider;
	public Slider shieldSlider;

	public void CallActivateLifeCount(ref float health){
		StartCoroutine (ActivateLifeCount(health));
	}
    public void CallDeactivateLifeCount() {
        DeactivateLifeCount();
    }

	public void CallHealthChange(ref float health, float amount, ref bool isInvulnerable, float enemyDamage, ref int shieldCount){
			if(!isInvulnerable || amount >= 0){
				if(shieldCount > 0 && amount <= 0){
				CallShieldChange (ref shieldCount, -1);
					return;
				}
				if(amount < 0 && amount + enemyDamage >= 0){
					return;
				}
				amount += enemyDamage;

				health += amount;
				if(health  < 0){
					health = 0;
				}else if(health > 5){
					amount = 5 - (health - amount);
					health = 5;
				}
				StopCoroutine(LifeCountVisual(0f,0f));
				StartCoroutine (LifeCountVisual(amount, health));
			}
	}
	public void CallShieldChange(ref int shieldCount, int amount){
		if(shieldCount >= 3 && amount > 0){
			return;
		}
		shieldCount += amount;
		StopCoroutine (ShieldCountVisual(0f, 0));
		StartCoroutine (ShieldCountVisual(amount, shieldCount));
	}

	private IEnumerator ActivateLifeCount(float health){
		yield return new WaitForSeconds (1);
		healthSlider.value = 0;
		healthSlider.gameObject.SetActive (true);
		shieldSlider.gameObject.SetActive (true);
		for(float f = 0f; f < health; f += 0.05f){
			healthSlider.value = f;
			yield return new WaitForSeconds (0.01f);//mebe chNGe
		}
	}
    private void DeactivateLifeCount() {
        healthSlider.gameObject.SetActive(false);
        shieldSlider.gameObject.SetActive(false);
    }
	private IEnumerator LifeCountVisual(float amount, float health){
		if (amount > 0) {
			for(float f = health-amount; f < health; f += 0.05f){
				healthSlider.value = f;
				yield return new WaitForSeconds (0.01f);//,mebi shcange
			}
		} else if(amount < 0){
			for(float f = health+amount*-1; f > health; f -= 0.05f){
				healthSlider.value = f;
				yield return new WaitForSeconds (0.01f);//change amybe if too fast
			}
		}
	}
	private IEnumerator ShieldCountVisual(float amount, int shieldCount){
		if (amount > 0) {
			for(float f = shieldCount-amount; f < shieldCount; f += 0.05f){
				shieldSlider.value = f;
				yield return new WaitForSeconds (0.01f);//,mebi shcange
			}
		} else if(amount < 0){
			for(float f = shieldCount+amount*-1; f > shieldCount; f -= 0.05f){
				shieldSlider.value = f;
				yield return new WaitForSeconds (0.01f);//change amybe if too fast
			}
		}
	}
}
