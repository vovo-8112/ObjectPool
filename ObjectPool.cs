using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _objectPrefab;
    [SerializeField] private int _initialPoolSize = 10;
    [SerializeField] private bool _initializeOnAwake = true;
    [SerializeField] private bool _activateOnGet = true;

    private readonly List<T> _pool = new();
    private bool _isInitialized;

    private void Awake()
    {
        if (_initializeOnAwake)
            InitializePool();
    }

    private void InitializePool()
    {
        if (_isInitialized) return;

        for (int i = 0; i < _initialPoolSize; i++)
        {
            T obj = CreatePooledObject();
            obj.gameObject.SetActive(false);
            _pool.Add(obj);
        }

        _isInitialized = true;
    }

    public T GetObject(bool? overrideActive = null)
    {
        if (!_isInitialized)
            InitializePool();

        bool shouldActivate = overrideActive ?? _activateOnGet;

        foreach (T obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(shouldActivate);
                return obj;
            }
        }

        T newObj = CreatePooledObject();
        newObj.gameObject.SetActive(shouldActivate);
        _pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(T obj)
    {
        if (_pool.Contains(obj))
            obj.gameObject.SetActive(false);
    }

    private T CreatePooledObject()
    {
        return Instantiate(_objectPrefab, transform);
    }
}