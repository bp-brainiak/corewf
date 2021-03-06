// This file is part of Core WF which is licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace CoreWf.DurableInstancing
{
    using System;
    using CoreWf.Runtime;
    using CoreWf.Runtime.DurableInstancing;
    using CoreWf.Internals;

    [Fx.Tag.XamlVisible(false)]
    public sealed class DeleteWorkflowOwnerCommand : InstancePersistenceCommand
    {
        public DeleteWorkflowOwnerCommand()
            : base(InstancePersistence.ActivitiesCommandNamespace.GetName("DeleteWorkflowOwner"))
        {
        }

        protected internal override bool IsTransactionEnlistmentOptional
        {
            get
            {
                return true;
            }
        }

        protected internal override void Validate(InstanceView view)
        {
            if (!view.IsBoundToInstanceOwner)
            {
                throw FxTrace.Exception.AsError(new InvalidOperationException(SR.OwnerRequired));
            }
        }
    }
}
