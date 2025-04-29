# 🔁 Generic Object Pool for Unity

This is a generic, reusable object pooling system for Unity using C# generics.  
It helps optimize performance by reusing components instead of instantiating and destroying them frequently.

## 📦 Features

- Generic support: works with any `MonoBehaviour`-derived `Component`.
- Automatic initialization on `Awake` (optional).
- Customizable initial pool size.
- Optional automatic activation of objects when retrieved.
- Lazy expansion: creates new objects if the pool runs out.
- Manual return of objects to the pool.

## 🧠 Usage

### 1. Create a Prefab
Create a prefab of the `Component` you want to pool (e.g., a bullet, enemy, UI panel, etc.).

### 2. Add the ObjectPool Script
Attach the `ObjectPool<T>` script to a GameObject in your scene.

### 3. Assign the Prefab
In the Inspector, assign your prefab to the `_objectPrefab` field and set other parameters as needed:

- `_initialPoolSize` — how many objects to preload in the pool.
- `_initializeOnAwake` — whether to create the pool on `Awake()`.
- `_activateOnGet` — whether to activate objects automatically when retrieved.

### 4. Get and Return Objects
