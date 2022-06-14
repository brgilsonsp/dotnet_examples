﻿using System;

namespace Util.InnerException
{
    public class ConfigureObjectException : BaseInnerException
    {
        public ConfigureObjectException(string message) : base(message) { }

        public ConfigureObjectException(string message, Exception exception) : base(message, exception) { }
    }
}
