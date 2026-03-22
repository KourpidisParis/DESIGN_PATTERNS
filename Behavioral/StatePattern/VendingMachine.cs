using System;

namespace DesignPatterns.Behavioral.StatePattern
{
    /// <summary>
    /// Context - Vending machine that changes states
    /// </summary>
    public class VendingMachine
    {
        private IState _noCoinState;
        private IState _hasCoinState;
        private IState _productSelectedState;
        private IState _currentState;

        public VendingMachine()
        {
            _noCoinState = new NoCoinState();
            _hasCoinState = new HasCoinState();
            _productSelectedState = new ProductSelectedState();

            // Initial state
            _currentState = _noCoinState;
        }

        public void SetState(IState state)
        {
            _currentState = state;
        }

        public void InsertCoin()
        {
            _currentState.InsertCoin(this);
        }

        public void EjectCoin()
        {
            _currentState.EjectCoin(this);
        }

        public void SelectProduct()
        {
            _currentState.SelectProduct(this);
        }

        public void Dispense()
        {
            _currentState.Dispense(this);
        }

        // Getters for states
        public IState GetNoCoinState()
        {
            return _noCoinState;
        }

        public IState GetHasCoinState()
        {
            return _hasCoinState;
        }

        public IState GetProductSelectedState()
        {
            return _productSelectedState;
        }

        public void ShowCurrentState()
        {
            string stateName = _currentState.GetType().Name;
            Console.WriteLine($"\n[Current State: {stateName}]");
        }
    }
}