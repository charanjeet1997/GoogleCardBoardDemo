using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RaycastSelectionManager
{
	public class BaseSelector : MonoBehaviour
	{
		#region PUBLIC_VARS

		public RaycastHit raycastHit;
		public Ray ray;
		public bool isObjectSelected;
	    #endregion

	    #region PRIVATE_VARS
	    
	    #endregion

	    #region UNITY_CALLBACKS

	    private void OnEnable()
	    {
		    SelectionManager.Instance.AddSelectors(this);
	    }

	    private void OnDisable()
	    {
		    SelectionManager.Instance.RemoveSelector(this);
	    }

	    #endregion

	    #region PUBLIC_METHODS

	    public virtual void OnSelectorSelected(Ray ray,RaycastHit hit)
	    {
		    this.ray = ray;
		    this.raycastHit = hit;
		    Debug.Log("Selected");
		    isObjectSelected = true;
	    }

	    public virtual void OnSelectorRemoved()
	    {
		    isObjectSelected = false;
	    }
	    #endregion

	    #region PRIVATE_METHODS

	    #endregion

	}
}