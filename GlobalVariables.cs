
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vorgari.Modules.BDO;

namespace Vorgari {
    static class GlobalVariables {

        public static string cmdPrefix = "!";
        public static Dictionary<string, ITrigger> _GarmothTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _KarandaTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _KzarkaTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _NouverTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _KutumTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _QuintTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _MurakaTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _VellTimes = new Dictionary<string, ITrigger>();
        public static Dictionary<string, ITrigger> _OffinTimes = new Dictionary<string, ITrigger>();
        public static List<(string, string)> _bossAvatars = new List<(string, string)>();

        public static void Init() {
            InitBossAvatars();
            InitBossTimers();
        }

        public static void InitBossAvatars() {
            _bossAvatars.Add(("Garmoth", "https://bdobosstimer.com/img/bosses/garmoth.png"));
            _bossAvatars.Add(("Nouver", "https://bdobosstimer.com/img/bosses/nouver.png"));
            _bossAvatars.Add(("Kutum", "https://bdobosstimer.com/img/bosses/kutum.png"));
            _bossAvatars.Add(("Karanda", "https://bdobosstimer.com/img/bosses/karanda.png"));
            _bossAvatars.Add(("Quint", "https://bdobosstimer.com/img/bosses/quint.png"));
            _bossAvatars.Add(("Muraka", "https://bdobosstimer.com/img/bosses/muraka.png"));
            _bossAvatars.Add(("Kzarka", "https://bdobosstimer.com/img/bosses/kzarka.png"));
            _bossAvatars.Add(("Vell", "https://bdobosstimer.com/img/bosses/vell.png"));
            _bossAvatars.Add(("OffinTett", "https://bdobosstimer.com/img/bosses/offin.png"));
        }

        public static void InitBossTimers() {
            _GarmothTimes = new Dictionary<string, ITrigger>();
            _NouverTimes = new Dictionary<string, ITrigger>();
            _KutumTimes = new Dictionary<string, ITrigger>();
            _KarandaTimes = new Dictionary<string, ITrigger>();
            _QuintTimes = new Dictionary<string, ITrigger>();
            _MurakaTimes = new Dictionary<string, ITrigger>();
            _KzarkaTimes = new Dictionary<string, ITrigger>();
            _VellTimes = new Dictionary<string, ITrigger>();
            _OffinTimes = new Dictionary<string, ITrigger>();
            #region Garmoth
            CreateSchedule("GarmothMon1", "Monday", 00, 00);
            CreateSchedule("GarmotWed1", "Wednesday", 03, 15);
            CreateSchedule("GarmothFri1", "Friday", 03, 15);
            #endregion
            #region Nouver
            CreateSchedule("NouverMon1", "Monday", 03, 15);
            CreateSchedule("NouverTue1", "Tuesday", 00, 00);
            CreateSchedule("NouverTue2", "Tuesday", 14, 00);
            CreateSchedule("NouverTue3", "Tuesday", 21, 00);
            CreateSchedule("NouverWed1", "Wednesday", 17, 00);
            CreateSchedule("NouverThu1", "Thursday", 05, 15);
            CreateSchedule("NouverThu2", "Thursday", 17, 00);
            CreateSchedule("NouverFri1", "Friday", 07, 00);
            CreateSchedule("NouverFri2", "Friday", 21, 00);
            CreateSchedule("NouverSat1", "Saturday", 10, 00);
            CreateSchedule("NouverSat2", "Staurday", 17, 00);
            CreateSchedule("NouverSun1", "Sunday", 05, 15);
            CreateSchedule("NouverSun2", "Sunday", 14, 00);
            #endregion
            #region Kutum
            CreateSchedule("KutumMon1", "Monday", 05, 15);
            CreateSchedule("KutumMon2", "Monday", 21, 00);
            CreateSchedule("KutumTue1", "Tuesday", 07, 00);
            CreateSchedule("KutumTue2", "Tuesday", 17, 00);
            CreateSchedule("KutumWed1", "Wednesday", 05, 15);
            CreateSchedule("KutumWed2", "Wednesday", 21, 00);
            CreateSchedule("KutumThu1", "Thursday", 07, 00);
            CreateSchedule("KutumThu2", "Thursday", 14, 00);
            CreateSchedule("KutumFri1", "Friday", 00, 00);
            CreateSchedule("KutumFri2", "Friday", 14, 00);
            CreateSchedule("KutumSat1", "Saturday", 03, 15);
            CreateSchedule("KutumSat2", "Saturday", 14, 00);
            CreateSchedule("KutumSun1", "Sunday", 05, 15);
            CreateSchedule("KutumSun2", "Sunday", 10, 00);
            #endregion
            #region Karanda
            CreateSchedule("KarandaMon1", "Monday", 05, 15);
            CreateSchedule("KarandaMon2", "Monday", 07, 00);
            CreateSchedule("KarandaTue1", "Tuesday", 05, 15);
            CreateSchedule("KarandaWed1", "Wednesday", 00, 00);
            CreateSchedule("KarandaWed2", "Wednesday", 07, 00);
            CreateSchedule("KarandaWed3", "Wednesday", 14, 00);
            CreateSchedule("KarandaThu1", "Thursday", 03, 15);
            CreateSchedule("KarandaFri1", "Friday", 05, 15);
            CreateSchedule("KarandaFri2", "Friday", 10, 00);
            CreateSchedule("KarandaFri3", "Friday", 17, 00);
            CreateSchedule("KarandaSat1", "Saturday", 05, 15);
            CreateSchedule("KarandaSun1", "Sunday", 00, 00);
            #endregion
            #region Quint
            CreateSchedule("QuintThu1", "Thursday", 04, 15);
            CreateSchedule("QuintSat1", "Saturday", 21, 00);
            #endregion
            #region Muraka
            CreateSchedule("MurakaThu1", "Thursday", 04, 15);
            CreateSchedule("MurakaSat1", "Saturday", 21, 00);
            #endregion
            #region Kzarka
            CreateSchedule("KzarkaMon1", "Monday", 03, 15);
            CreateSchedule("KzarkaMon2", "Monday", 10, 00);
            CreateSchedule("KzarkaMon3", "Monday", 14, 00);
            CreateSchedule("KzarkaTue1", "Tuesday", 03, 15);
            CreateSchedule("KzarkaTue2", "Tuesday", 10, 00);
            CreateSchedule("KzarkaWed1", "Wednesday", 05, 15);
            CreateSchedule("KzarkaThu1", "Thursday", 03, 15);
            CreateSchedule("KzarkaThu2", "Thursday", 10, 00);
            CreateSchedule("KzarkaFri1", "Friday", 05, 15);
            CreateSchedule("KzarkaSat1", "Saturday", 00, 00);
            CreateSchedule("KzarkaSat2", "Saturday", 03, 15);
            CreateSchedule("KzarkaSun1", "Sunday", 00, 00);
            CreateSchedule("KzarkaSun2", "Sunday", 07, 00);
            CreateSchedule("KzarkaSun3", "Sunday", 17, 00);
            #endregion
            #region Vell
            CreateSchedule("VellSun1", "Sunday", 21, 00);
            #endregion
            #region Offin Tett
            CreateSchedule("OffinTettMon1", "Monday", 17, 00);
            CreateSchedule("OffinTettThu1", "Thursday", 00, 00);
            CreateSchedule("OffinTettSat1", "Saturday", 07, 00);
            #endregion
        }

        public static async void CreateSchedule(string bossName, string dayOfWeek, int hour, int min) {
            NameValueCollection props = new NameValueCollection();
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();
            await scheduler.Start();

            var job = JobBuilder.CreateForAsync<BossNotifications>()
                .WithIdentity(bossName)
                .Build();

            DayOfWeek day = DayOfWeek.Monday;
            switch (dayOfWeek) {
                case "Monday":
                    break;
                case "Tuesday":
                    day = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    day = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    day = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    day = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    day = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    day = DayOfWeek.Sunday;
                    break;
            }

            Dictionary<string, ITrigger> dir = new Dictionary<string, ITrigger>();
            switch (bossName.Substring(0,3)) {
                case "Gar":
                    dir = _GarmothTimes;
                    break;
                case "Kza":
                    dir = _KzarkaTimes;
                    break;
                case "Kar":
                    dir = _KarandaTimes;
                    break;
                case "Kut":
                    dir = _KutumTimes;
                    break;
                case "Nou":
                    dir = _NouverTimes;
                    break;
                case "Qui":
                    dir = _QuintTimes;
                    break;
                case "Mur":
                    dir = _MurakaTimes;
                    break;
                case "Vel":
                    dir = _VellTimes;
                    break;
                case "Off":
                    dir = _OffinTimes;
                    break;
            }

            var trigger = TriggerBuilder.Create()
                .WithIdentity(bossName)
                .WithSchedule(CronScheduleBuilder
                    .WeeklyOnDayAndHourAndMinute(day, hour, min)
                    .InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("UTC")))
                .ForJob(job)
                .Build();

            await scheduler.ScheduleJob(job, trigger);
            await scheduler.DeleteJob(job.Key);
            dir.Add(bossName, trigger);
        }
    }
}
