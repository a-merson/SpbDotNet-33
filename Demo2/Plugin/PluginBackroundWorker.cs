using System;
using System.Collections.Generic;
using System.Text;
using Abp;
using Abp.Dependency;
using Abp.Notifications;
using Abp.Threading;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;

namespace Plugin
{
    public class PluginBackroundWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly INotificationPublisher _notificationPublisher;

        public PluginBackroundWorker(AbpTimer timer, INotificationPublisher notificationPublisher) 
            : base(timer)
        {
            _notificationPublisher = notificationPublisher;
            Timer.Period = 30000;
        }
        protected override void DoWork()
        {
			Console.WriteLine("Sending notification");
            AsyncHelper.RunSync(() => _notificationPublisher.PublishAsync(
                                    "SpbDotNetNotification",
                                    data: new MessageNotificationData("Не забудьте про бар после митапа!"),
                                    severity: NotificationSeverity.Warn,
                                    userIds: new[] { new UserIdentifier(2, 4), }));
        }
    }
}
