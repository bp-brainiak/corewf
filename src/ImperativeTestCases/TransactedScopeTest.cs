﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using CoreWf;
using CoreWf.Statements;

namespace ImperativeTestCases
{

    sealed class TransactionScopeTest : Activity
    {
        public TransactionScopeTest()
        {
            this.Implementation = () => new Sequence
            {
                Activities =
                {
                    new WriteLine { Text = "    Begin TransactionScopeTest" },

                    new TransactionScope
                    {
                        Body = new Sequence
                        {
                            Activities =
                            {
                                new WriteLine { Text = "    Begin TransactionScopeTest TransactionScope" },
                                new PrintTransactionId(),
                                new WriteLine { Text = "    End TransactionScopeTest TransactionScope" },
                            },
                        },
                    },

                    new WriteLine { Text = "    End TransactionScopeTest" },
                }
            };
        }
    }
}
