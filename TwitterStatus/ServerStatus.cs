namespace TwitterStatus
{
    class ServerStatus
    {
        public int requests_count { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public int success_count { get; set; }
        public int error_count { get; set; }

        public int RequestsCount
        {
            get { return requests_count; }
        }

        public int SuccessCount
        {
            get { return success_count; }
        }

        public int ErrorCount
        {
            get { return error_count; }
        }
    }
}
