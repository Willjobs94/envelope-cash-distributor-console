using EasyConsole;
using EnvelopeDistributorConsole.Pages;

namespace EnvelopeDistributorConsole
{
    public class MainPage : MenuPage
    {
        public MainPage(Program program)
            : base("Main Page", program,
                new Option("View Envelope", () => program.NavigateTo<ViewEnvelopePage>()),
                new Option("Create Envelope", () => program.NavigateTo<CreateEnvelopePage>()),
                new Option("Show Bill Envelope Distribution", () => program.NavigateTo<BillDistributionPage>())
                ) { }
    }
}
