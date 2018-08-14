using System.Linq;
using EasyConsole;

namespace EnvelopeDistributorConsole.Pages
{
    public class ViewEnvelopePage : Page
    {

        public ViewEnvelopePage(Program program) : base($"View Envelope {Runner.Context.Envelopes.Count}", program)
        {
            //Runner.Context
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Envelopes");
            var envelopes = Runner.Context.Envelopes;
            if (envelopes!=null && envelopes.Any())
            {
                foreach (var envelope in envelopes)
                {
                    Output.WriteLine($"Name: {envelope.Name}, Total: {envelope.Amount}");
                }
            }
            else
            {
                Output.WriteLine("There's not envelope to show");
            }
           
            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}