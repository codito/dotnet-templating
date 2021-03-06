﻿using System;
using System.Collections.Generic;
using Microsoft.TemplateEngine.Abstractions.PhysicalFileSystem;

namespace Microsoft.TemplateEngine.Abstractions
{
    public interface ITemplateEngineHost
    {
        IReadOnlyList<KeyValuePair<Guid, Func<Type>>> BuiltInComponents { get; }

        IPhysicalFileSystem FileSystem { get; }

        string HostIdentifier { get; }

        IReadOnlyList<string> FallbackHostTemplateConfigNames { get; }

        string Version { get; }

        string Locale { get; }
        
        void LogMessage(string message);

        void OnCriticalError(string code, string message, string currentFile, long currentPosition);

        bool OnNonCriticalError(string code, string message, string currentFile, long currentPosition);

        // return of true means a new value was provided
        bool OnParameterError(ITemplateParameter parameter, string receivedValue, string message, out string newValue);

        void OnSymbolUsed(string symbol, object value);

        void OnTimingCompleted(string label, TimeSpan timing);

        bool TryGetHostParamDefault(string paramName, out string value);

        void UpdateLocale(string newLocale);

        void VirtualizeDirectory(string path);
    }
}
