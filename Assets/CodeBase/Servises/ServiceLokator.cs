using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLokator
{
    private static ServiceLokator _instance;
    public static ServiceLokator Container => _instance ?? (_instance = new ServiceLokator());

    public void RegistrateAsSingl<TService>(TService servise) where TService : IService
    {
        Implementation<TService>.ServiceImplementation = servise;
    }

    public TService Single<TService>() where TService : IService
    {
        return Implementation<TService>.ServiceImplementation;
    }

    private static class Implementation<TService> where TService : IService
    {
        public static TService ServiceImplementation;
        
    }
    
}
