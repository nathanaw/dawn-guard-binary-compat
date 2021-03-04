using Dawn;
namespace Example.DawnConsumerLib
{
    public class Test
    {
        public void Foo(string bar)
        {
            // ****************************************************************
            // This will throw a MissingMethodException because the 
            // signature changed between version 1.0.0 and 1.4.1
            // ----------------------------------------------------------------
            // See https://www.fuget.org/packages/Dawn.Guard/1.4.0/lib/netstandard2.0/diff/1.3.0/
            // Note the removals.
            // ----------------------------------------------------------------
            // Root cause of binary break is the addition of ctor / method params wtih defaults.
            // These are resolved at compile time, not runtime. 
            // Hence they are not binary backward compatible.
            // ----------------------------------------------------------------
            // Unhandled exception. System.MissingMethodException: Method not found: 'ArgumentInfo`1<!!0> Dawn.Guard.Argument(!!0, System.String)'.
            //   at Example.DawnConsumerLib.Test.Foo(String bar)
            //   at Example.DawnConsole.Program.Main(String[] args) in .\Example.DawnConsole\Program.cs:line 10
            // ****************************************************************
            Guard.Argument(bar, nameof(bar)).NotNull();
        }
    }
}
