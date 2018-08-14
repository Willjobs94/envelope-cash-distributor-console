using System.Collections;
using System.Collections.Generic;

namespace EnvelopeDistributorConsole
{
    public class MockedLiteDbContext
    {
        public List<Envelope> Envelopes { get; set; } = new List<Envelope>
        {
            new Envelope
            {
                Amount = 2500,
                Name = "Sistema Educativo",
            },
            new Envelope
            {
                Amount = 2500,
                Name = "Sistema Educativo",
            },
            new Envelope
            {
                Amount = 1000,
                Name = "Seminario",
            },
            new Envelope
            {
                Amount = 9500,
                Name = "Casa",
            },
            new Envelope
            {
                Amount = 1250,
                Name = "Pasaje T",
            },
            new Envelope
            {
                Amount = 1200,
                Name = "Dentista",
            },
            new Envelope
            {
                Amount = 2000,
                Name = "Convencion",
            }
        };
    }
}