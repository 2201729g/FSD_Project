using System.Security.Claims;

namespace FSD_Project.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string DriversEndpoint = $"{Prefix}/drivers";

        public static readonly string CustomersEndpoint = $"{Prefix}/customers";

        public static readonly string BillsEndpoint = $"{Prefix}/bills";

        public static readonly string FeedbacksEndpoint = $"{Prefix}/feedbacks";

        public static readonly string IncidentReportsEndpoint = $"{Prefix}/incidentReports";


    }
}
