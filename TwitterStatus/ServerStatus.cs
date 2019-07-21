namespace TwitterStatus
{
    class ServerStatus
    {
        public int RequestsCount { get; set; }
        public string Application { get; set; }
        public string Version { get; set; }
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }

        public override string ToString()
        {
            return Application;
        }
    }
}
