using System;

namespace Example.DawnConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Example.DawnConsumerLib.Test();

            // ****************************************************************
            // This line will throw a MissingMethodException because the signature of the ArgumentInfo struct 
            // changed between version 1.3.0 and 1.4.0.
            // ----------------------------------------------------------------
            // See https://www.fuget.org/packages/Dawn.Guard/1.4.0/lib/netstandard2.0/diff/1.3.0/
            // Note the removals.
            // ----------------------------------------------------------------
            // The changes would apprear to be backward compatible, and they are at compile time.
            // Adding a new optional parameter is not binary compatible because the default value
            // is resolved at compile time.
            // ----------------------------------------------------------------
            // This violates semantic versioning, and causes problems when a library
            // compiled against a version <= 1.3.0 is used in a process that loaded
            // a version >= 1.4.0. This is common when an ecosystem of libraries all use
            // Dawn, but are on different versions.
            // ****************************************************************

            lib.Foo("test");
        }
    }
}
