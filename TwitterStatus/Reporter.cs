using System;
using System.Collections.Generic;

namespace TwitterStatus
{
    // TODO: Would be better to use dependency injection rather than static,
    // but punted in the interest of time
    static class Reporter
    {
        private static Dictionary<VersionedApplication, ApplicationStatus> applicationStatuses = new Dictionary<VersionedApplication, ApplicationStatus>();

        public static void AddStatus(ServerStatus serverStatus)
        {
            ApplicationStatus applicationStatus = new ApplicationStatus(serverStatus);
            VersionedApplication statusApplicationVersion = new VersionedApplication(serverStatus);

            if (!applicationStatuses.ContainsKey(statusApplicationVersion))
            {
                applicationStatuses.Add(statusApplicationVersion, applicationStatus);
            } else
            {
                applicationStatuses[statusApplicationVersion].AddStatus(applicationStatus);
            }
        }

        // Assuming we want to write the report to the console rather than to disk,
        // but we may want to have another method for 'exporting' the report
        public static void PrintStatuses()
        {
            foreach(KeyValuePair<VersionedApplication, ApplicationStatus> entry in applicationStatuses)
            {
                Console.WriteLine(entry.Key.Application + "," + entry.Key.Version);
            }
        }

        private class VersionedApplication
        {
            public string Application { get; set; }
            public string Version { get; set; }

            public VersionedApplication(ServerStatus serverStatus)
            {
                this.Application = serverStatus.Application;
                this.Version = serverStatus.Version;
            }
        }

        private class ApplicationStatus
        {
            private int requestCount = 0;
            private int successCount = 0;
            // Requirements Assumption: Error count wasn't specified in the requirements, but it may later prove useful
            // in some scenario, to troubleshoot the internal error tracking of app instances, so we'll hang on to the data
            private int errorCount = 0;

            public ApplicationStatus(ServerStatus serverStatus)
            {
                this.requestCount = serverStatus.RequestsCount;
                this.successCount = serverStatus.SuccessCount;
                this.errorCount = serverStatus.ErrorCount;
            }

            public void AddStatus(ApplicationStatus status)
            {
                this.requestCount += status.requestCount;
                this.successCount += status.successCount;
                this.errorCount += status.errorCount;
            }
        }
    }
}
