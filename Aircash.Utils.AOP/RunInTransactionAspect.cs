using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Transactions;

namespace Aircash.Utils.AOP
{
    [Serializable]
    [AspectTypeDependency(AspectDependencyAction.Order,
                           AspectDependencyPosition.After, typeof(LoggerAspect))]
    public class RunInTransactionAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        TransactionScope TransactionScope;
        private string filePath = @"C:\Log\Log.txt";
        private Guid _methodCallIdentifier;

        public override void OnEntry(MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();

            Debug.WriteLine("Transaction start.");
            this.TransactionScope = new TransactionScope(TransactionScopeOption.RequiresNew);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Transaction start on method :" + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();

            Debug.WriteLine("Transaction success.");
            this.TransactionScope.Complete();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Transaction sucess on method: " + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public override void OnException(MethodExecutionArgs args)
        {

            _methodCallIdentifier = Guid.NewGuid();

            args.FlowBehavior = FlowBehavior.Continue;
            Transaction.Current.Rollback();
            Debug.WriteLine("Transaction Was Unsuccessful!");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Transaction Was Unsuccessful on method: " + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _methodCallIdentifier = Guid.NewGuid();

            Debug.WriteLine("Transaction end.");
            this.TransactionScope.Dispose();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Guid: " + _methodCallIdentifier + Environment.NewLine + "Transaction end on method: " + args.Method.Name + Environment.NewLine +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine("-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }
}
