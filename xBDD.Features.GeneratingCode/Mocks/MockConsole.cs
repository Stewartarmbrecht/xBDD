namespace xBDD.Features.GeneratingCode.Mocks
{
    using McMaster.Extensions.CommandLineUtils;
    using System.Text;
    using System.IO;
    using System;

    internal class MockConsole: IConsole
    {
        public StringWriter Output = new StringWriter();
        public TextWriter Out { get { return Output; } }
        //
        // Summary:
        //     stderr
        public TextWriter Error { get { return Output; } }
        //
        // Summary:
        //     stdin
        public TextReader In { get {
            throw new NotImplementedException();
        } }
        //
        // Summary:
        //     Is stdin piped from somewhere?
        public bool IsInputRedirected { get {
            return false;
        } }
        //
        // Summary:
        //     Is stdout being piped to somewhere?
        public bool IsOutputRedirected { get {
            return false;
        } }
        //
        // Summary:
        //     Is stderr being piped to somewhere?
        public bool IsErrorRedirected { get {
            return false;
        } }
        //
        // Summary:
        //     The foreground color of output.
        public ConsoleColor ForegroundColor { get; set; }
        //
        // Summary:
        //     The background color of output.
        public ConsoleColor BackgroundColor { get; set; }

        //
        // Summary:
        //     Raised when Ctrl+C is pressed.
        public event ConsoleCancelEventHandler CancelKeyPress;

        //
        // Summary:
        //     Resets McMaster.Extensions.CommandLineUtils.IConsole.ForegroundColor and McMaster.Extensions.CommandLineUtils.IConsole.BackgroundColor.
        public void ResetColor() {
            throw new System.NotImplementedException();
        }
    }
}