﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Threading;
using Moq;

namespace Microsoft.VisualStudio.ProjectSystem.LanguageServices
{
    internal static class IApplyChangesToWorkspaceContextFactory
    {
        public static IApplyChangesToWorkspaceContext Create()
        {
            return Mock.Of<IApplyChangesToWorkspaceContext>();
        }

        public static IApplyChangesToWorkspaceContext ImplementApplyProjectBuild(Action<IProjectVersionedValue<IProjectSubscriptionUpdate>, bool, CancellationToken> action)
        {
            var mock = new Mock<IApplyChangesToWorkspaceContext>();
            mock.Setup(c => c.ApplyProjectBuild(It.IsAny<IProjectVersionedValue<IProjectSubscriptionUpdate>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback(action);

            return mock.Object;
        }

        public static IApplyChangesToWorkspaceContext ImplementApplyProjectEvaluation(Action<IProjectVersionedValue<IProjectSubscriptionUpdate>, bool, CancellationToken> action)
        {
            var mock = new Mock<IApplyChangesToWorkspaceContext>();
            mock.Setup(c => c.ApplyProjectEvaluation(It.IsAny<IProjectVersionedValue<IProjectSubscriptionUpdate>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback(action);

            return mock.Object;
        }
    }
}
