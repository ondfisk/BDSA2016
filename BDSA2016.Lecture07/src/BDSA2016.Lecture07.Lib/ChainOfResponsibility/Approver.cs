﻿namespace BDSA2016.Lecture07.Lib.ChainOfResponsibility
{
    public abstract class Approver
    {
        protected Approver _successor;

        public void SetSuccessor(Approver successor)
        {
            _successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
