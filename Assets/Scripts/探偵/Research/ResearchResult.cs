namespace 探偵
{
    public class ResearchResult
    {
        public bool Success { get; }
        public string ErrorMessage { get; }
        public ResearchReport Report { get; }

        ResearchResult(bool success, string errorMessage, ResearchReport report)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Report = report;
        }

        public static ResearchResult Ok(ResearchReport report)
        {
            return new ResearchResult(true, null, report);
        }

        public static ResearchResult Failure(string message)
        {
            return new ResearchResult(false, message, new ResearchReport());
        }
    }
}
