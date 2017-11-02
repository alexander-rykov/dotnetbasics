namespace CustomAttributes
{
    // TODO Uncomment all custom attributes.
    public interface IMyService
    {
        // [DefaultValue("SomeValue")]
        string MyProperty { get; }

        // [DefaultValue("135")]
        int AnotherProperty { get; }

        // [LogMethodCall]
        int DoSomething(
            // [NotNullOrEmpty]
            string stringParameter,
            // [MaxValue(120)]
            int parameter);

        // [RedirectMethodCall("CalculateSum")]
        int DoSomethingElse(int x, int y);
    }
}
