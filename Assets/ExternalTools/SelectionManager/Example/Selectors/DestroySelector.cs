using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RaycastSelectionManager
{
	public class DestroySelector : BaseSelector
	{
		#region PUBLIC_VARS

		public float maxDestroyTime;
		public Image fillImage;
		public GameObject blastParticle;
	    #endregion

	    #region PRIVATE_VARS
		private float currentTime = 0;
		[SerializeField] private float maxHealth;
		[SerializeField] private float currentHealth;
		[SerializeField] private float healthDecrease;
		[SerializeField] private float score;
		[SerializeField] private ScoreContainer _scoreContainer;
	    #endregion

	    #region UNITY_CALLBACKS

	    private void Start()
	    {
		    currentHealth = maxHealth;
	    }

	    #endregion

	    #region PUBLIC_METHODS
	    public override void OnSelectorSelected(Ray ray, RaycastHit hit)
	    {
		    base.OnSelectorSelected(ray, hit);
		    
	    }
	    public override void OnSelectorRemoved()
	    {
		    base.OnSelectorRemoved();
	    }

	    private void OnCollisionEnter(Collision other)
	    {
		    if (other.collider.tag == Constants.canonBallTag)
		    {
			    currentHealth -= healthDecrease;
			    fillImage.fillAmount = currentHealth / maxHealth;
			    if (currentHealth <= 0)
			    {
				    Instantiate(blastParticle, transform.position, Quaternion.identity);
				    OnSelectorRemoved();
				    _scoreContainer.UpdateScore(score);
				    Destroy(this.gameObject);
			    }
		    }
	    }

	    #endregion

	    #region PRIVATE_METHODS
	    
	    #endregion
	}
}