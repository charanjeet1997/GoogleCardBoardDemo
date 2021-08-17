using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RaycastSelectionManager
{
	public class SelectionManager : MonoBehaviour
	{
		#region PUBLIC_VARS
		public static SelectionManager Instance
		{
			get => instance;
			private set => instance = value;
		}
	    public List<BaseSelector> Selectors
	    {
		    get => _selectors;
		    set => _selectors = value;
	    }

	    public UnityEvent OnSelectionHit;
	    #endregion

	    #region PRIVATE_VARS
	    private static SelectionManager instance;
	    [SerializeField] private List<BaseSelector> _selectors;
	    [SerializeField]private List<BaseSelector> tempSelections = new List<BaseSelector>();
	    #endregion

	    #region UNITY_CALLBACKS
	    private void Awake()
	    {
		    instance = this;
	    }

	    #endregion

	    #region PUBLIC_METHODS
	    public void AddSelectors(BaseSelector selector)
	    {
		    if(_selectors == null)
			    _selectors = new List<BaseSelector>();
		    _selectors.Add(selector);
	    }

	    public void RemoveSelector(BaseSelector selector)
	    {
		    _selectors.Remove(selector);
	    }

	    public void OnSelectorRaycast(Ray ray,out RaycastHit hit,float maxDistance = 30)
	    {
		    if (Physics.Raycast(ray, out hit,maxDistance))
		    {
				Debug.Log("Working");
			    for (int indexOfSelectors = 0; indexOfSelectors < _selectors.Count; indexOfSelectors++)
			    {
				    if (hit.collider.gameObject == _selectors[indexOfSelectors].gameObject)
				    {
					    if(tempSelections.Find(x => x.gameObject ==_selectors[indexOfSelectors].gameObject))
					    tempSelections.Add(_selectors[indexOfSelectors]);
					    _selectors[indexOfSelectors].OnSelectorSelected(ray, hit);
				    }
				    else
				    {
					    tempSelections.Remove(_selectors[indexOfSelectors]);
					    _selectors[indexOfSelectors].OnSelectorRemoved();
				    }
			    }
		    }
	    }

	    public void OnDisselectSelector()
	    {
		    for (int indexOfSelectors = 0; indexOfSelectors < _selectors.Count; indexOfSelectors++)
		    {
			    _selectors[indexOfSelectors].OnSelectorRemoved();
		    }
	    }

	    public bool IsSelectableSelected()
	    {
		    bool isSelected = false;
		    for (int indexOfSelectors = 0; indexOfSelectors < _selectors.Count; indexOfSelectors++)
		    {
			    if (_selectors[indexOfSelectors].isObjectSelected)
			    {
				    isSelected = true;
			    }
		    }
		    return isSelected;
	    }
	    #endregion

	    #region PRIVATE_METHODS
		
	    #endregion
	}
}
