using EasyConsole;

namespace EnvelopeDistributorConsole.Pages
{
    public class CreateEnvelopePage : Page
    {
        public CreateEnvelopePage(Program program) : base("Create Envelope", program)
        {

        }

        public override void Display()
        {
            base.Display();
            var envelopeName = Input.ReadString("Enter Envelope Name: ");
            var envelopeAmount = (decimal)Input.ReadInt("Enter envelope amount: ", 0, 100000);

            var envelope = new Envelope
            {
                Amount = envelopeAmount,
                Name = envelopeName
            };

            Runner.Context.Envelopes.Add(envelope);

            Program.NavigateBack();
        }
    }
}