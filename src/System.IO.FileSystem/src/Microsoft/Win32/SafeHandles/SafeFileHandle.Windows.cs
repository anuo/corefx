// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace Microsoft.Win32.SafeHandles
{
    [System.Security.SecurityCritical]  // auto-generated_required
    public sealed class SafeFileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private bool? _isAsync;

        private SafeFileHandle() : base(true)
        {
            _isAsync = null;
        }

        public SafeFileHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle)
        {
            SetHandle(preexistingHandle);

            _isAsync = null;
        }

        internal bool? IsAsync
        {
            get
            {
                return _isAsync;
            }

            set
            {
                _isAsync = value;
            }
        }

        internal ThreadPoolBoundHandle ThreadPoolBinding { get; set; }

        [System.Security.SecurityCritical]
        override protected bool ReleaseHandle()
        {
            return Interop.mincore.CloseHandle(handle);
        }
    }
}

